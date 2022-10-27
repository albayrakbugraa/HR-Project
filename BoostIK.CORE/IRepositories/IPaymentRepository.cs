using BoostIK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.IRepositories
{
    public interface IPaymentRepository:IBaseRepository<Payment>
    {
        Task<bool> DeleteRequestInDatabase(Payment entity);
    }
}
