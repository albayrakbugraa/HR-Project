using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.DayOffRequestRepository
{
    public interface IDayOffRequestService
    {
        Task<bool> AddNewDailyRequest(RequestDailyVM model);
        Task<bool> AddNewHourlyRequest(RequestHourlyVM model);
        Task<List<DayOffRequestVM>> GetDayOffRequestByPersonelID(string id);
        Task<bool> DeleteRequestInDatabase(Guid id);
        Task<List<DayOffRequestVM>> GetAllDayOffRequest(Guid companyId);
    }
}
