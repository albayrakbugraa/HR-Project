using BoostIK.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<bool> AddNewPaymentRequest(PaymentVM model);
        Task<List<PaymentVM>> GetPaymentByPersonelID(string id);
        Task<bool> DeletePaymentInDatabase(Guid id);
    }
}
