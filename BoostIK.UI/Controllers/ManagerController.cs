using AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.DTOs.PermissionLimit;
using BoostIK.BLL.Models.VMs;
using BoostIK.BLL.Validators;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.UI.Utils;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BoostIK.UI.Controllers
{
    public class ManagerController : Controller
    {
        const string apiUrl = "https://localhost:44368/api/";

        private readonly UserManager<Personel> usermanager;
        private readonly IWebHostEnvironment environment;
        private readonly IMapper mapper;
        private readonly ClaimService claimService;

        public ManagerController(UserManager<Personel> usermanager, IWebHostEnvironment _environment, IMapper mapper)
        {
            this.usermanager = usermanager;
            environment = _environment;
            this.mapper = mapper;
            claimService = new ClaimService(usermanager);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + "Manager/GetManagerCardByID/" + userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            ManagerCardVM vm = JsonConvert.DeserializeObject<ManagerCardVM>(result);
            return View(vm);
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public async Task<IActionResult> GetManagerCard()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + "Manager/GetManagerCardByID/" + userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            ManagerCardVM vm = JsonConvert.DeserializeObject<ManagerCardVM>(result);
            return PartialView("_ManagerCardPartial", vm);
        }

        public async Task<IActionResult> GetPersonelInfo()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + "Manager/GetManagerCardByID/" + userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                UpdatePersonelDTO updatePersonelDTO = JsonConvert.DeserializeObject<UpdatePersonelDTO>(result);
                return Json(updatePersonelDTO);
            }

            return BadRequest("error");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdatePersonelDTO model)
        {
            string url = apiUrl + "Manager/UpdateManager";

            if (ModelState.IsValid)
            {
                if (model.newPhoto != null)
                {
                    using var image = Image.Load(model.newPhoto.OpenReadStream());
                    if (image.Height > 512 && image.Width > 512)
                        image.Mutate(x => x.Resize(512, 512));

                    string fileName = $"{model.Id}.jpg";
                    image.Save($"wwwroot/images/users/{fileName}");

                    model.ImagePath = $"/images/users/{fileName}";
                    model.newPhoto = null;

                    Personel user = await usermanager.GetUserAsync(User);
                    await claimService.ReplaceClaims(user);
                }

                HttpClient client = new HttpClient();
                string jsonObject = JsonConvert.SerializeObject(model);
                HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

                if (response.IsSuccessStatusCode) return Json(new { result = true });
                return Json(new { result = false });
            }
            else
            {
                var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return Json(errs);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDayOffRequest()
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);
            string url = apiUrl + "Manager/GetDayOffRequestByCompanyId/" + personel.CompanyID;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<DayOffRequestVM> requests = new List<DayOffRequestVM>();

            string result = await response.Content.ReadAsStringAsync();
            requests = JsonConvert.DeserializeObject<List<DayOffRequestVM>>(result);

            return View(requests);
        }
    }
}
