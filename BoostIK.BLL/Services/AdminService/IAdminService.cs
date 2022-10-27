using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.AdminService
{
    public interface IAdminService
    {
        Task<AdminCardVM> GetAdminCard(string adminId);

        Task<UpdateAdminDTO> GetAdminEditInfo(string adminId);
        Task<bool> UpdateAdmin(UpdateAdminDTO model);


    }
}
