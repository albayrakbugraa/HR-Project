using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PersonelService
{
    public interface IPersonelService
    {
        Task<PersonelCardVM> GetPersonelCardByID(string id);
        Task<ManagerCardVM> GetManagerCardByID(string id);
        Task<bool> UpdatePersonelByManager(UpdatePersonelByManagerDTO model);
        Task<bool> UpdatePersonel(UpdatePersonelDTO model);
        Task<bool> UpdatePersonelPassword(ResetPasswordDTO model);
        Task<bool> CreatePersonel(CreatePersonelDTO model);
        Task<bool> CreateManager(CreateManagerDTO model);

        Task<UpdatePersonelDTO> GetPersonelEditInfo(string id);
        Task<List<PersonelCardVM>> GetActivePersonelsByCompanyId(Guid companyId);
        Task<List<PersonelCardVM>> GetPassivePersonelsByCompanyId(Guid companyId);
        Task<List<ManagerVM>> GetManagers();

    }
}
