using AutoMapper;
using BoostIK.BLL.Models.DTOs.PermissionLimit;
using BoostIK.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PermissionLimitService
{
    public class PermissionLimitService : IPermissionLimitService
    {
        private readonly IPermissionLimitRepository permissionLimitRepository;
        private readonly IMapper mapper;

        public PermissionLimitService(IPermissionLimitRepository permissionLimitRepository, IMapper mapper)
        {
            this.permissionLimitRepository = permissionLimitRepository;
            this.mapper = mapper;
        }

        public async Task<List<PermissionLimitDTO>> GetPermissionLimitsByCompany(Guid companyId)
        {
            var limits = await permissionLimitRepository.GetFilteredList(
                selector : x => new PermissionLimitDTO{
                    CompanyID = x.CompanyID,
                    Gender = x.Permission.Gender,
                    MaxDayCount = x.MaxDayCount,
                    PermissionID = x.PermissionID,
                    PermissionLimitID = x.ID,
                    PermissionName = x.Permission.Name
                },
                expression: x => x.CompanyID == companyId,
                orderBy : x => x.OrderBy(x => x.PermissionID),
                includes : x => x.Include(x => x.Permission)
                );

            return limits;
        }
    }
}
