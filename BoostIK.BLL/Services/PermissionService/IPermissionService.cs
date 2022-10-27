using BoostIK.BLL.Models.DTOs.PermissionLimit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<List<PermissionLimitDTO>> GetDefaultPermissionLimits();
    }
}
