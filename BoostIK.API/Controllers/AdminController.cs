using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.BLL.Services.AdminService;
using BoostIK.BLL.Services.CompanyService;
using BoostIK.BLL.Services.PersonelService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoostIK.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IPersonelService personelService;
        private readonly IAdminService adminService;

        public AdminController(ICompanyService companyService, IPersonelService personelService, IAdminService adminService)
        {
            this.companyService = companyService;
            this.personelService = personelService;
            this.adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetActiveCompanies()
        {
            var companies = await companyService.GetActiveCompanies();
            return Ok(companies);
        }

        public async Task<IActionResult> GetCompaniesWithNoManager()
        {
            var companies = await companyService.GetCompaniesWithNoManager();
            return Ok(companies);
        }

        [HttpGet, Route("{adminId}")]
        public async Task<IActionResult> GetAdminCard(string adminId)
        {
            AdminCardVM card = await adminService.GetAdminCard(adminId);
            if (card == null) return BadRequest(new { status = false, description = "Not found" });
            return Ok(card);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetAdminEditInfo(string id)
        {
            UpdateAdminDTO updateDTO = await adminService.GetAdminEditInfo(id);
            if (updateDTO == null) return BadRequest();
            return Ok(updateDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDTO model)
        {
            bool result = await adminService.UpdateAdmin(model);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO model)
        {
            bool result = await companyService.CreateCompany(model);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            CompanyVM company = await companyService.GetCompanyById(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateManagerDTO model)
        {
            bool result = await personelService.CreateManager(model);
            if (result) return Ok();
            return BadRequest();
        }
        public async Task<IActionResult> GetManagers()
        {
            var managers = await personelService.GetManagers();
            return Ok(managers);
        }

    }
}
