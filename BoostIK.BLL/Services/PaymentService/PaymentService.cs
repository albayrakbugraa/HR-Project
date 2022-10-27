using AutoMapper;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.CORE.IRepositories;
using BoostIK.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        private readonly IPaymentRepository paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository,IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        public async Task<bool> AddNewPaymentRequest(PaymentVM model)
        {
            decimal sumAmount=0;
            List<Payment> payments=await paymentRepository.GetAllWhere(x => x.CreationDate >= DateTime.Now.AddYears(-1) && x.PersonelID==model.PersonelID);
            foreach (var item in payments)
            {
                sumAmount += item.Amount;
            }            
            if (sumAmount + model.Amount > model.Salary)
            {
                return false;
            }
            Payment payment = new Payment();
            payment = mapper.Map(model, payment);
            var result =await paymentRepository.Create(payment);
            return result;
        }

        public async Task<bool> DeletePaymentInDatabase(Guid id)
        {
            Payment payment = await paymentRepository.GetWhere(a => a.PaymentID == id);
            if (payment == null) return false;
            else if (payment.State != RequestState.Bekliyor) return false;
            return await paymentRepository.DeleteRequestInDatabase(payment);
        }

        public async Task<List<PaymentVM>> GetPaymentByPersonelID(string id)
        {
            var paymentVM = await paymentRepository.GetFilteredList(
                selector: x => new PaymentVM
                {
                    PaymentID = x.PaymentID,
                    Amount = x.Amount,
                    Description = x.Description,
                    CompanyID = x.CompanyID,
                    CreationDate = x.CreationDate,
                    DeleteDate = x.DeleteDate,
                    CurrencyUnit = x.CurrencyUnit,
                    ReplyDate = x.ReplyDate,
                    UpdateDate = x.UpdateDate,
                    State = x.State,
                    RefuseDescription = x.RefuseDescription                    
                },
                expression: x => x.PersonelID == id && x.Status == true,
                orderBy: x=>x.OrderByDescending(x=>x.CreationDate)
                );
            return paymentVM;            
        }
    }
}
