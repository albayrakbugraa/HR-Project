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
    public class PersonelController : Controller
    {
        
        const string apiUrl = "https://localhost:44368/api/";
        Guid tempCompanyID = new System.Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b");
        string tempPersonelID = "76cd1492-a593-4e7c-a1fa-5fe5677d6a99";

        private readonly UserManager<Personel> usermanager;
        private readonly IWebHostEnvironment environment;
        private readonly IMapper mapper;
        private readonly ClaimService claimService;

        public PersonelController(UserManager<Personel> usermanager, IWebHostEnvironment _environment, IMapper mapper)
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
            string url = apiUrl + "Personel/GetPersonelCardByID/"+ userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            PersonelCardVM vm = JsonConvert.DeserializeObject<PersonelCardVM>(result);
            return View(vm);
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public async Task<IActionResult> GetPersonelCard()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + "Personel/GetPersonelCardByID/"+ userId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            PersonelCardVM vm = JsonConvert.DeserializeObject<PersonelCardVM>(result);
            return PartialView("_PersonelCardPartial", vm);
        }

        public async Task<IActionResult> GetPersonelInfo()
        {
            // login olmuş olan userın id'si ile apiye talepte bulunulacak
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + "Personel/GetPersonelCardByID/" + userId;
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
        public async Task<IActionResult> UpdatePersonel(UpdatePersonelDTO model)
        {
            string url = apiUrl + "Personel/UpdatePersonel";

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
        public async Task<IActionResult> GunlukIzinTalebi()
        {
            List<PermissionLimitDTO> limits = await GetPermissionLimits();
            ViewBag.Limits = limits;

            RequestDailyVM vm = new RequestDailyVM();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> GunlukIzinTalebi(RequestDailyVM model)
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);
            model.CompanyID = (Guid)personel.CompanyID;
            model.PersonelID = personel.Id;
            string url = apiUrl + "Personel/RequestDaily";

            List<string> izinErrors = new List<string>();
            List<PermissionLimitDTO> limits = await GetPermissionLimits();
            ViewBag.Limits = limits;


            int yillikIzin = 7;
            if (model.PermissionID == 1 && model.DayCount > yillikIzin)
            {
                izinErrors.Add("Kalan yıllık izninizden fazla yıllık izin talep edemezsiniz.");
                ViewBag.errors = izinErrors;
                ViewBag.result = false;
                return View(model);
            }

            if (model.File != null)
            {
                model.FilePath = await IzinBelgeKaydet(model.File);
                model.File = null;
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                return View();
            }

            var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            ViewBag.errors = errs;
            ViewBag.result = false;
            return View(model);
        }

        public IActionResult HarcamaTalebi()
        {
            ViewBag.TypeOfSpendings = Enum.GetValues(typeof(TypeOfSpending));
            ViewBag.CurrencyUnits = Enum.GetValues(typeof(CurrencyUnit));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HarcamaTalebi(SpendingVM model)
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);
            model.CompanyID = (Guid)personel.CompanyID;
            model.PersonelID = personel.Id;
            string url = apiUrl + "Personel/RequestSpending";
            List<string> harcamaErrors = new List<string>();

            ViewBag.TypeOfSpendings = Enum.GetValues(typeof(TypeOfSpending));
            ViewBag.CurrencyUnits = Enum.GetValues(typeof(CurrencyUnit));

            if (model.File == null)
            {
                harcamaErrors.Add("Lütfen harcama belgesini ekleyin.");
                ViewBag.errors = harcamaErrors;
                ViewBag.result = false;
                return View(model);                
            }
            model.FilePath = await HarcamaBelgeKaydet(model.File);
            model.File = null;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                return View();
            }
            var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            ViewBag.errors = errs;
            ViewBag.result = false;
            return View(model);
        }

        public IActionResult AvansTalebi()
        {
            ViewBag.CurrencyUnits = Enum.GetValues(typeof(CurrencyUnit));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AvansTalebi(PaymentVM model)
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);
            model.CompanyID = (Guid)personel.CompanyID;
            model.PersonelID = personel.Id;
            model.Salary = (decimal)personel.Salary;
            string url = apiUrl + "Personel/RequestPayment";
            List<string> avansErrors = new List<string>();

            ViewBag.CurrencyUnits = Enum.GetValues(typeof(CurrencyUnit));

            if (model.Amount >personel.Salary)
            {
                avansErrors.Add("Avans tutarınız maaşınızdan fazla olamaz.");
                ViewBag.errors = avansErrors;
                ViewBag.result = false;
                return View(model);
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                return View();
            }
            var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            ViewBag.errors = errs;
            ViewBag.result = false;
            return View(model);
        }

        [HttpGet]
        public IActionResult SaatlikIzinTalebi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaatlikIzinTalebi(RequestHourlyVM model)
        {
            
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);

            model.CompanyID = (Guid)personel.CompanyID;
            model.PersonelID = personel.Id;
            model.PermissionID = 12;
            model.EndDate = model.StartDate;
            model.StartHour = new DateTime(model.StartDate.Year, model.StartDate.Month, model.StartDate.Day, model.StartHour.Hour, model.StartHour.Minute, 0);
            model.EndHour = new DateTime(model.StartDate.Year, model.StartDate.Month, model.StartDate.Day, model.EndHour.Hour, model.EndHour.Minute, 0);

            if (!ModelState.IsValid)
            {
                ViewBag.result = false;
                var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                ViewBag.errors = errs;
                return View(model);
            }

            string url = apiUrl + "Personel/RequestHourly";
            HttpClient client = new HttpClient();
            //string jsonObject = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                return View();
            }
            else
            {
                ViewBag.result = false;
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> IzinTaleplerim()
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);

            string url = apiUrl + "Personel/GetDayOffRequestByPersonelId/" + personel.Id;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<DayOffRequestVM> requests = new List<DayOffRequestVM>();

            string result = await response.Content.ReadAsStringAsync();
            requests = JsonConvert.DeserializeObject<List<DayOffRequestVM>>(result);

            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> HarcamaTaleplerim()
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);

            string url = apiUrl + "Personel/GetSpendingByPersonelId/" + personel.Id;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<SpendingVM> requests = new List<SpendingVM>();

            string result = await response.Content.ReadAsStringAsync();
            requests = JsonConvert.DeserializeObject<List<SpendingVM>>(result);

            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> AvansTaleplerim()
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);

            string url = apiUrl + "Personel/GetPaymentByPersonelId/" + personel.Id;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<PaymentVM> requests = new List<PaymentVM>();

            string result = await response.Content.ReadAsStringAsync();
            requests = JsonConvert.DeserializeObject<List<PaymentVM>>(result);

            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> IzinTalebiIptal(Guid izinId)
        {
            string url = apiUrl + "Personel/DeleteRequestInDatabase/" + izinId;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            return RedirectToAction("IzinTaleplerim");
        }

        [HttpGet]
        public async Task<IActionResult> HarcamaTalebiIptal(Guid harcamaId)
        {
            string url = apiUrl + "Personel/DeleteSpendingInDatabase/" + harcamaId;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            return RedirectToAction("HarcamaTaleplerim");
        }

        [HttpGet]
        public async Task<IActionResult> AvansTalebiIptal(Guid avansId)
        {
            string url = apiUrl + "Personel/DeletePaymentInDatabase/" + avansId;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            return RedirectToAction("AvansTaleplerim");
        }

        private async Task<string> IzinBelgeKaydet(IFormFile file)
        {
            string wwwPath = environment.WebRootPath;
            string contentPath = environment.ContentRootPath;
            string path = Path.Combine(environment.WebRootPath, "files\\izin-belge");
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            string fileName = $"{timeStamp}-{file.FileName}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            fileName = Path.GetFileName(fileName);

            FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await file.CopyToAsync(stream);

            return $"\\files\\izin-belge\\{fileName}";
        }
        private async Task<string> HarcamaBelgeKaydet(IFormFile file)
        {
            string wwwPath = environment.WebRootPath;
            string contentPath = environment.ContentRootPath;
            string path = Path.Combine(environment.WebRootPath, "files\\harcama-belge");
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            string fileName = $"{timeStamp}-{file.FileName}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            fileName = Path.GetFileName(fileName);

            FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await file.CopyToAsync(stream);

            return $"\\files\\harcama-belge\\{fileName}";
        }

        private async Task<List<PermissionLimitDTO>> GetPermissionLimits()
        {
            Personel personel = await usermanager.GetUserAsync(HttpContext.User);
            string url = apiUrl + "Permission/GetPermissionLimits/" + personel.CompanyID;

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<PermissionLimitDTO> limits = new List<PermissionLimitDTO>();

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                limits = JsonConvert.DeserializeObject<List<PermissionLimitDTO>>(result);
            }
            else
            {
                // eğer yukarıda bir hata olursa sistem default limitleri getirecek
                var responseDefault = await client.GetAsync(apiUrl + "Permission/GetDefaultPermissionLimits");
                string resultDefault = await responseDefault.Content.ReadAsStringAsync();
                limits = JsonConvert.DeserializeObject<List<PermissionLimitDTO>>(resultDefault);
            }

            // personel yıllık iznini yıllık izin dto'suna ekliyor ve kendi ve all olan izin tiplerini filtreliyor
            limits.FirstOrDefault(a => a.PermissionID == 1).MaxDayCount = (int)personel.RemaningAnnualLeave;
            limits = limits.Where(a => (a.Gender == personel.Gender || a.Gender == CORE.Enums.Gender.Hepsi) && a.PermissionName != "Saatlik").ToList();

            return limits;
        }

      
    }
}
