using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.UI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.UI.Controllers
{
    public class AdminController : Controller
    {
        const string apiUrl = "https://localhost:44368/api/";
        private readonly UserManager<Personel> userManager;
        private readonly ClaimService claimService;

        public AdminController(UserManager<Personel> usermanager)
        {
            this.userManager = usermanager;
            claimService = new ClaimService(userManager);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + $"Admin/GetAdminCard/{userId}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            AdminCardVM vm = JsonConvert.DeserializeObject<AdminCardVM>(result);
            return View(vm);
        }

        public async Task<IActionResult> GetAdminCard()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + $"Admin/GetAdminCard/{userId}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            AdminCardVM vm = JsonConvert.DeserializeObject<AdminCardVM>(result);
            return PartialView("_AdminCardPartial", vm);
        }

        public async Task<IActionResult> GetAdminEditInfo()
        {
            string userId = User.Claims.First(z => z.Type == "userId").Value;
            string url = apiUrl + $"Admin/GetAdminEditInfo/{userId}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                UpdateAdminDTO updateAdminDTO = JsonConvert.DeserializeObject<UpdateAdminDTO>(result);
                return Json(updateAdminDTO);
            }

            return BadRequest("error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDTO model)
        {
            string url = apiUrl + "Admin/UpdateAdmin";

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


                    Personel user = await userManager.GetUserAsync(User);
                    await claimService.ReplaceClaims(user);

                    //IEnumerable<Claim> claims = await userManager.GetClaimsAsync(user);
                    //await userManager.RemoveClaimsAsync(user, claims);

                    //await userManager.AddClaimAsync(user, new Claim("userId", user.Id));
                    //await userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
                    //await userManager.AddClaimAsync(user, new Claim("photoPath", user.ImagePath));
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

        public IActionResult CreateCompany()
        {
            ViewBag.Cities = Enum.GetValues(typeof(City));

            var trades = Enum.GetValues(typeof(TradeNameType));
            List<SelectListItem> liss = new List<SelectListItem>();
            foreach (TradeNameType item in trades)
            {
                liss.Add(new SelectListItem { Value = ((int)item).ToString(), Text = item.GetDisplayName() });
            }

            ViewBag.TradeNameTypes = liss;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO model)
        {
            ViewBag.Cities = Enum.GetValues(typeof(City));
            var trades = Enum.GetValues(typeof(TradeNameType));
            List<SelectListItem> liss = new List<SelectListItem>();
            foreach (TradeNameType item in trades)
            {
                liss.Add(new SelectListItem { Value = ((int)item).ToString(), Text = item.GetDisplayName() });
            }

            ViewBag.TradeNameTypes = liss;

            string url = apiUrl + "Admin/CreateCompany";
            List<string> companyErrors = new List<string>();

            if (model.Logo != null)
            {
                using var image = Image.Load(model.Logo.OpenReadStream());
                if (image.Height > 512 && image.Width > 512)
                    image.Mutate(x => x.Resize(512, 512));
                string fileName = $"{model.CompanyID}.jpg";
                image.Save($"wwwroot/images/companies/{fileName}");
                model.LogoPath = $"/images/companies/{fileName}";
                model.Logo = null;
            }

            string jsonObject = JsonConvert.SerializeObject(model);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                return RedirectToAction("GetActiveCompanies");
            }
            var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            ViewBag.errors = errs;
            ViewBag.result = false;
            return View(model);

        }
        public async Task<IActionResult> GetActiveCompanies()
        {
            string url = apiUrl + "Admin/GetActiveCompanies";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<CompanyVM> companies = new List<CompanyVM>();
            string result = await response.Content.ReadAsStringAsync();
            companies = JsonConvert.DeserializeObject<List<CompanyVM>>(result);
            return View(companies);
        }

        public async Task<IActionResult> CreateManager()
        {
            string url = apiUrl + "Admin/GetCompaniesWithNoManager";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<CompanyVM> companies = new List<CompanyVM>();
            string result = await response.Content.ReadAsStringAsync();
            companies = JsonConvert.DeserializeObject<List<CompanyVM>>(result);
            ViewBag.companies = companies;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateManagerDTO model)
        {
            string companyUrl = apiUrl + "Admin/GetCompanyById/" + model.CompanyID;
            string createManagerUrl = apiUrl + "Admin/CreateManager";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(companyUrl);
            CompanyVM company = new CompanyVM();
            string result = await response.Content.ReadAsStringAsync();
            company = JsonConvert.DeserializeObject<CompanyVM>(result);

            string firstName=ConvertEngChar(model.FirstName);
            string lastName =ConvertEngChar(model.LastName);            
            model.Email = $"{firstName.ToLower()}.{lastName.ToLower()}{company.MailExtension}";
            

            string jsonObject = JsonConvert.SerializeObject(model);
            response = await client.PostAsJsonAsync(createManagerUrl, model);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = true;
                ViewBag.message = "İşlem başarıyla gerçekleştirildi";
                SmtpClient smp = new SmtpClient("smtp.mailtrap.io", 2525);
                smp.Credentials = new NetworkCredential("74ce1554031ed8", "fe2a91e05f0d9c");
                smp.EnableSsl = true;
                string subjects = "Yeni Şifre";
                string body = $"Yeni şifreniz: {model.Password}";
                smp.Send("admin@ikmerkezim.com", model.Email, subjects, body);
                return RedirectToAction("Index");
            }

            ViewBag.result = false;
            var errs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            ViewBag.errors = errs;

            string url = apiUrl + "Admin/GetCompaniesWithNoManager";
            response = await client.GetAsync(url);
            List<CompanyVM> companies = new List<CompanyVM>();
            result = await response.Content.ReadAsStringAsync();
            companies = JsonConvert.DeserializeObject<List<CompanyVM>>(result);
            ViewBag.companies = companies;


            return View(model);

        }

        public async Task<IActionResult> GetManagers()
        {
            string url = apiUrl + "Admin/GetManagers";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            List<ManagerVM> companies = new List<ManagerVM>();
            string result = await response.Content.ReadAsStringAsync();
            companies = JsonConvert.DeserializeObject<List<ManagerVM>>(result);
            return View(companies);
        }

        public static string ConvertEngChar(string metin)
        {

            char[] türkcekarakterler = {'ı','ğ','İ','Ğ','ç','Ç','ş','Ş','ö','Ö','ü','Ü'};
            char[] ingilizce = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U' };
            for (int i = 0; i < türkcekarakterler.Length; i++)
            {

                metin = metin.Replace(türkcekarakterler[i], ingilizce[i]);

            }
            return metin;
        }

    }
}
