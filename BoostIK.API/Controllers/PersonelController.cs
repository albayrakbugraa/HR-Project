using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.BLL.Services.DayOffRequestRepository;
using BoostIK.BLL.Services.PaymentService;
using BoostIK.BLL.Services.PersonelService;
using BoostIK.BLL.Services.SpendingService;
using BoostIK.BLL.Validators;
using BoostIK.CORE.Enums;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoostIK.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService personelService;
        private readonly IDayOffRequestService dayOffRequestService;
        private readonly ISpendingService spendingService;
        private readonly IPaymentService paymentService;

        public PersonelController(IPersonelService personelService, IDayOffRequestService dayOffRequestService, ISpendingService spendingService,IPaymentService paymentService)
        {
            this.personelService = personelService;
            this.dayOffRequestService = dayOffRequestService;
            this.spendingService = spendingService;
            this.paymentService = paymentService;
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetPersonelCardByID(string id)
        {
            PersonelCardVM card = await personelService.GetPersonelCardByID(id);
            return Ok(card);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetPersonelEditInfo(string id)
        {
            UpdatePersonelDTO updateDTO = await personelService.GetPersonelEditInfo(id);
            if (updateDTO == null) return BadRequest();
            return Ok(updateDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonel(UpdatePersonelDTO model)
        {
            bool result = await personelService.UpdatePersonel(model);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RequestDaily(RequestDailyVM model)
        {
            RequestDailyVMValidator vl = new RequestDailyVMValidator();
            ValidationResult result = await vl.ValidateAsync(model);

            await dayOffRequestService.AddNewDailyRequest(model);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> RequestSpending(SpendingVM model)
        {
            SpendingVMValidator vl = new SpendingVMValidator();
            ValidationResult result = await vl.ValidateAsync(model);

            await spendingService.AddNewSpendingRequest(model);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> RequestPayment(PaymentVM model)
        {
            PaymentVMValidator vl = new PaymentVMValidator();
            ValidationResult result = await vl.ValidateAsync(model);
            bool serviceResult = await paymentService.AddNewPaymentRequest(model);
            if (serviceResult) return Ok();
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> RequestHourly(RequestHourlyVM model)
        {
            await dayOffRequestService.AddNewHourlyRequest(model);
            return Ok();
        }

        //[HttpGet, Route("{id}&{restType}")]
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetDayOffRequestByPersonelId(string id)
        {
            List<DayOffRequestVM> dayOffRequestVMList = await dayOffRequestService.GetDayOffRequestByPersonelID(id);
            return Ok(dayOffRequestVMList);
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetSpendingByPersonelId(string id)
        {
            List<SpendingVM> spendingVMs = await spendingService.GetSpendingByPersonelID(id);
            return Ok(spendingVMs);
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetPaymentByPersonelId(string id)
        {
            List<PaymentVM> paymentVMs = await paymentService.GetPaymentByPersonelID(id);
            return Ok(paymentVMs);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> DeleteRequestInDatabase(Guid id)
        {
            bool result = await dayOffRequestService.DeleteRequestInDatabase(id);
            if(result) return Ok();
            return BadRequest();
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> DeleteSpendingInDatabase(Guid id)
        {
            bool result = await spendingService.DeleteSpendingInDatabase(id);
            if (result) return Ok();
            return BadRequest();
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> DeletePaymentInDatabase(Guid id)
        {
            bool result = await paymentService.DeletePaymentInDatabase(id);
            if (result) return Ok();
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePersonelPassword(ResetPasswordDTO model)
        {
            bool result = await personelService.UpdatePersonelPassword(model);
            if (result) return Ok();
            return BadRequest();
        }

    }
}
