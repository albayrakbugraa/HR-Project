using BoostIK.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using BoostIK.BLL.Models.VMs;
using BoostIK.BLL.Models.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using BoostIK.UI.Utils;

namespace BoostIK.UI.Controllers
{
    public class AccountController : Controller
    {
        const string apiUrl = "https://localhost:44368/api/";
        Guid tempCompanyID = new System.Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b");
        string tempPersonelID = "76cd1492-a593-4e7c-a1fa-5fe5677d6a99";
        private readonly UserManager<Personel> userManager;
        private readonly SignInManager<Personel> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ClaimService claimService;

        public AccountController(UserManager<Personel> userManager, SignInManager<Personel> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            claimService = new ClaimService(userManager);
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            Personel personel =await userManager.FindByEmailAsync(model.Email);
            if (personel == null) 
            {
                ModelState.AddModelError("Giriş başarısız..", "Geçersiz kullanıcı adı veya şifre !");
                return View(model);
            }

            await claimService.AddClaimsToUser(personel);
            //await userManager.AddClaimAsync(personel, new Claim("userId", personel.Id));
            //await userManager.AddClaimAsync(personel, new Claim("firstName", personel.FirstName));
            //await userManager.AddClaimAsync(personel, new Claim("photoPath", personel.ImagePath));
            SignInResult result=await signInManager.PasswordSignInAsync(personel, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(personel);
                if (roles.Contains("Admin")) return RedirectToAction(controllerName: "Admin", actionName: "Index");
                if (roles.Contains("Manager") && !personel.isPasswordChanged) return RedirectToAction(controllerName: "Manager", actionName: "Index");
                if (roles.Contains("Manager") && personel.isPasswordChanged) return RedirectToAction("ResetPassword");
                if (!personel.isPasswordChanged) return RedirectToAction(actionName: "Index", controllerName: "Personel");
                else return RedirectToAction("ResetPassword");
            }

            ModelState.AddModelError("Giriş başarısız..", "Geçersiz kullanıcı adı veya şifre !");
            return View(model);

        }
        
        public IActionResult ResetPasswordRequest()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ResetPasswordRequest(ResetPasswordDTO model)
        {
            string url = apiUrl + "Personel/UpdatePersonelPassword";
            Guid guid = Guid.NewGuid();
            string password = guid.ToString().Substring(0, 8);
            Personel personel = await userManager.FindByEmailAsync(model.Email);
            if (personel != null)
            {
                SmtpClient smp = new SmtpClient("smtp.mailtrap.io", 2525);
                smp.Credentials = new NetworkCredential("74ce1554031ed8", "fe2a91e05f0d9c");
                smp.EnableSsl = true;
                string subjects = "Yeni Şifre Talebi";
                string body = $"Yeni şifreniz: {password}";
                smp.Send("bilgeadam@ikmerkezim.com", personel.Email,subjects,body);
                model.Id = personel.Id;
                model.Password=password;
                model.isPasswordChanged=true;
                HttpClient client = new HttpClient();
                string jsonObject = JsonConvert.SerializeObject(model);
                HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
        }
        
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO model)
        {
            string url = apiUrl + "Personel/UpdatePersonelPassword";
            Personel personel = await userManager.GetUserAsync(User);
            model.Id=personel.Id;
            model.Email=personel.Email;
            model.isPasswordChanged = false;
            HttpClient client = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
            return RedirectToAction(actionName:"LogOut",controllerName:"Account");
        }

        public async Task<IActionResult> LogOut()
        {
            Personel personel =await userManager.GetUserAsync(User);
            await claimService.RemoveClaims(personel);
            //await userManager.RemoveClaimsAsync(personel, User.Claims);
            await signInManager.SignOutAsync();
            return View("Login");
        }

    }
}
