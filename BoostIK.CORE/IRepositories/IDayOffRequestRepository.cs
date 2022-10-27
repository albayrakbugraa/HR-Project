using BoostIK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.IRepositories
{
    public interface IDayOffRequestRepository : IBaseRepository<DayOffRequest>
    {
        //Database'den komple silme
        Task<bool> DeleteRequestInDatabase(DayOffRequest entity);
    }
}
