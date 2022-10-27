using BoostIK.BLL.Models.DTOs.PermissionLimit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PermissionLimitService
{
    public interface IPermissionLimitService
    {
        Task<List<PermissionLimitDTO>> GetPermissionLimitsByCompany(Guid companyId);
    }
}
