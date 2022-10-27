using AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using BoostIK.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompanyService(ICompanyRepository companyRepository,IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        public async Task<bool> CreateCompany(CreateCompanyDTO model)
        {
            Company company = new Company();
            company = mapper.Map(model, company);
            return await companyRepository.Create(company);
        }

        public async Task<List<CompanyVM>> GetActiveCompanies()
        {
            List<CompanyVM> companies = await companyRepository.GetFilteredList(
                selector: x => new CompanyVM
                {
                    CompanyID = x.CompanyID,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    CreationDate = x.CreationDate,
                    ManagerName=x.Manager.FirstName+x.Manager.LastName,
                    PersonelCount=x.Personels.Count,
                    PhoneNumber = x.PhoneNumber,
                    TaxNumber = x.TaxNumber,
                    TradeName = x.TradeName,
                    Status = x.Status,
                    LogoPath=x.LogoPath,
                    MailExtension = x.MailExtension,
                    
                },
                includes: x => x.Include(c => c.Manager).Include(x=>x.Personels),
                expression: x => x.Status == true
                );
            return companies;
        }

        public async Task<List<CompanyVM>> GetCompaniesWithNoManager()
        {
            List<CompanyVM> companies = await companyRepository.GetFilteredList(
                selector: x => new CompanyVM
                {
                    CompanyID = x.CompanyID,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    CreationDate = x.CreationDate,
                    ManagerName = x.Manager.FirstName + x.Manager.LastName,
                    PersonelCount = x.Personels.Count,
                    PhoneNumber = x.PhoneNumber,
                    TaxNumber = x.TaxNumber,
                    TradeName = x.TradeName,
                    Status = x.Status,
                    LogoPath = x.LogoPath,
                    MailExtension = x.MailExtension,

                },
                includes: x => x.Include(c => c.Manager).Include(x => x.Personels),
                expression: x => x.Status == true && x.ManagerId == null
                );
            return companies;
        }

        public async Task<CompanyVM> GetCompanyById(Guid companyId)
        {
            CompanyVM company = await companyRepository.GetFilteredFirstOrDefault(
                selector : x => new CompanyVM
                {
                    CompanyID = x.CompanyID,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    CreationDate = x.CreationDate,
                    ManagerName = x.Manager.FirstName + x.Manager.LastName,
                    PersonelCount = x.Personels.Count,
                    PhoneNumber = x.PhoneNumber,
                    TaxNumber = x.TaxNumber,
                    TradeName = x.TradeName,
                    Status = x.Status,
                    LogoPath = x.LogoPath,
                    MailExtension = x.MailExtension,
                },
                includes: x => x.Include(c => c.Manager).Include(x => x.Personels),
                expression : x => x.CompanyID == companyId
                );
            return company;
        }

        public async Task<List<CompanyVM>> GetPassiveCompanies()
        {
            List<CompanyVM> companies = await companyRepository.GetFilteredList(
                selector: x => new CompanyVM
                {
                    CompanyID = x.CompanyID,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    CreationDate = x.CreationDate,
                    ManagerName = x.Manager.FirstName + x.Manager.LastName,
                    PersonelCount = x.Personels.Count,
                    PhoneNumber = x.PhoneNumber,
                    TaxNumber = x.TaxNumber,
                    TradeName = x.TradeName,
                    Status = x.Status,
                    LogoPath = x.LogoPath,
                    MailExtension = x.MailExtension,
                },
                includes: x => x.Include(c => c.Manager).Include(x => x.Personels),
                expression: x => x.Status == false
                );
            return companies;
        }

        public async Task<bool> UpdateCompany(UpdateCompanyDTO model)
        {
            Company company = await companyRepository.GetWhere(x => x.CompanyID == model.CompanyID);
            company = mapper.Map(model, company);
            return companyRepository.Update(company);
        }
    }
}
