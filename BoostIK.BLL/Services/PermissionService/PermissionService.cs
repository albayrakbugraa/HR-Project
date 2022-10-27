using AutoMapper;
using BoostIK.BLL.Models.DTOs.PermissionLimit;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly IMapper mapper;

        public PermissionService(IPermissionRepository permissionRepository ,IMapper mapper)
        {
            this.permissionRepository = permissionRepository;
            this.mapper = mapper;
        }

        public async Task<List<PermissionLimitDTO>> GetDefaultPermissionLimits()
        {
            var limits = await permissionRepository.GetFilteredList(
                selector: x => new PermissionLimitDTO
                {
                    CompanyID = new Guid(),
                    Gender = x.Gender,
                    MaxDayCount = x.MaxDayCount,
                    PermissionID = x.PermissionID,
                    PermissionLimitID = 0,
                    PermissionName = x.Name
                },
                expression: x => x.Status == true,
                orderBy: x => x.OrderBy(x => x.PermissionID)
                );

            return limits;
        }
    }
}
