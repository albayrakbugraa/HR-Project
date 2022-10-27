using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.BLL.Services.DayOffRequestRepository;
using BoostIK.BLL.Services.PaymentService;
using BoostIK.BLL.Services.PersonelService;
using BoostIK.BLL.Services.SpendingService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoostIK.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : Controller
    {        
        private readonly IPersonelService personelService;
        private readonly IDayOffRequestService dayOffRequestService;
        private readonly ISpendingService spendingService;
        private readonly IPaymentService paymentService;

        public ManagerController(IPersonelService personelService, IDayOffRequestService dayOffRequestService, ISpendingService spendingService, IPaymentService paymentService)
        {
            this.personelService = personelService;
            this.dayOffRequestService = dayOffRequestService;
            this.spendingService = spendingService;
            this.paymentService = paymentService;
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetManagerCardByID(string id)
        {
            ManagerCardVM card = await personelService.GetManagerCardByID(id);
            return Ok(card);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetManagerEditInfo(string id)
        {
            UpdatePersonelDTO updateDTO = await personelService.GetPersonelEditInfo(id);
            if (updateDTO == null) return BadRequest();
            return Ok(updateDTO);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdatePersonelDTO model)
        {
            bool result = await personelService.UpdatePersonel(model);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetDayOffRequestByCompanyId(Guid id)
        {
            List<DayOffRequestVM> dayOffRequestVMList = await dayOffRequestService.GetAllDayOffRequest(id);
            return Ok(dayOffRequestVMList);
        }
    }
}
