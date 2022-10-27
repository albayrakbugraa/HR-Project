using BoostIK.CORE.Entities;
using BoostIK.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BoostIK.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Personel> userManager;
        private readonly SignInManager<Personel> signInManager;

        public HomeController(UserManager<Personel> userManager,SignInManager<Personel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            Personel personel = await userManager.FindByIdAsync("76cd1492-a593-4e7c-a1fa-5fe5677d6a99");
            await signInManager.SignInAsync(personel, true);            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
