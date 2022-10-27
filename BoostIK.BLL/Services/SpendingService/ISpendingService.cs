using BoostIK.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.SpendingService
{
    public interface ISpendingService
    {
        Task<bool> AddNewSpendingRequest(SpendingVM model);
        Task<List<SpendingVM>> GetSpendingByPersonelID(string id);
        Task<bool> DeleteSpendingInDatabase(Guid id);
    }
}
