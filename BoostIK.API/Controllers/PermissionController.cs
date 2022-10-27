using BoostIK.BLL.Models.DTOs.PermissionLimit;
using BoostIK.BLL.Services.PermissionLimitService;
using BoostIK.BLL.Services.PermissionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoostIK.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionLimitService permissionLimitService;
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionLimitService permissionLimitService, IPermissionService permissionService)
        {
            this.permissionLimitService = permissionLimitService;
            this.permissionService = permissionService;
        }

        [HttpGet, Route("{companyId}")]
        public async Task<IActionResult> GetPermissionLimits(Guid companyId)
        {
            List<PermissionLimitDTO> limits = await permissionLimitService.GetPermissionLimitsByCompany(companyId);
            if (limits.Count > 0) return Ok(limits);
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultPermissionLimits()
        {
            List<PermissionLimitDTO> limits = await permissionService.GetDefaultPermissionLimits();
            return Ok(limits);
        }
    }
}
