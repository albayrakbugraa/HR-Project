using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<CompanyVM> GetCompanyById(Guid companyId);
        Task<bool> CreateCompany(CreateCompanyDTO model);
        Task<bool> UpdateCompany(UpdateCompanyDTO model);
        Task<List<CompanyVM>> GetActiveCompanies();
        Task<List<CompanyVM>> GetPassiveCompanies();
        Task<List<CompanyVM>> GetCompaniesWithNoManager();

    }
}
