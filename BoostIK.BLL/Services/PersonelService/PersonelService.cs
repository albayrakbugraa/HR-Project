using AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.CORE.IRepositories;
using BoostIK.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.PersonelService
{
    public class PersonelService : IPersonelService
    {
        private readonly UserManager<Personel> userManager;
        private readonly IPersonelRepository personelRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly SignInManager<Personel> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<Personel> passwordHasher;

        public PersonelService(UserManager<Personel> userManager, SignInManager<Personel> signInManager, RoleManager<IdentityRole> roleManager, IPersonelRepository personelRepository, ICompanyRepository companyRepository, IMapper mapper, IPasswordHasher<Personel> passwordHasher)
        {
            this.userManager = userManager;
            this.personelRepository = personelRepository;
            this.companyRepository = companyRepository;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<bool> CreatePersonel(CreatePersonelDTO model)
        {
            //Company id atanmış şekilde gelsin
            Personel user = new Personel();
            user = mapper.Map(model, user);

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, "Personel");

            return result.Succeeded;

            // Personel'e mail gönderilecek
        }
        public async Task<bool> CreateManager(CreateManagerDTO model)
        {
            Personel user = new Personel();
            user = mapper.Map(model, user);

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Manager");
                Company cp = await companyRepository.GetWhere(x => x.CompanyID == model.CompanyID);
                cp.ManagerId = user.Id;
                companyRepository.Update(cp);
            }
            else return false;

            return result.Succeeded;

            // Personel'e mail gönderilecek
        }

        public async Task<PersonelCardVM> GetPersonelCardByID(string id)
        {
            PersonelCardVM personelCard = await personelRepository.GetFilteredFirstOrDefault(
                selector: x => new PersonelCardVM
                {
                    Id = id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PersonelMail = x.PersonelMail,
                    Position = x.Position,
                    DepartmentName = x.Department.Name,
                    City = (City)x.City,
                    Adress = x.Adress,
                    MobilePhone = x.MobilePhone,
                    PhoneNumber = x.PhoneNumber,
                    ImagePath = x.ImagePath,
                    BirthDate = (DateTime)x.BirthDate
                },
                includes: x => x.Include(c => c.Department),
                expression: x => x.Id == id && x.Status == true
                );
            return personelCard;
        }

        public async Task<ManagerCardVM> GetManagerCardByID(string id)
        {
            ManagerCardVM personelCard = await personelRepository.GetFilteredFirstOrDefault(
                selector: x => new ManagerCardVM
                {
                    Id = id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Position = x.Position,
                    ImagePath = x.ImagePath,
                    CompanyName=x.Company.CompanyName
                },
                includes: x => x.Include(c => c.Company),
                expression: x => x.Id == id && x.Status == true
                );
            return personelCard;
        }

        public async Task<bool> UpdatePersonelPassword(ResetPasswordDTO model)
        {
            Personel user = await userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.isPasswordChanged = model.isPasswordChanged;
                user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                IdentityResult result = await userManager.UpdateAsync(user);
                return result.Succeeded;
            }
            else
                return false;
        }

        public async Task<bool> UpdatePersonel(UpdatePersonelDTO model)
        {
            Personel user = await userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user = mapper.Map(model, user);
                IdentityResult result = await userManager.UpdateAsync(user);
                return result.Succeeded;
            }
            else
                return false;
        }

        public async Task<bool> UpdatePersonelByManager(UpdatePersonelByManagerDTO model)
        {
            Personel user = await personelRepository.GetWhere(x => x.Id == model.Id);
            if (user != null)
            {
                user = mapper.Map(model, user);
                return personelRepository.Update(user);
            }
            else
                return false;
        }

        public async Task<UpdatePersonelDTO> GetPersonelEditInfo(string id)
        {
            UpdatePersonelDTO updateDTO = await personelRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdatePersonelDTO
                {
                    Id = id,
                    City = (City)x.City,
                    Adress = x.Adress,
                    PhoneNumber = x.PhoneNumber,
                    MobilePhone = x.MobilePhone,
                    ImagePath = x.ImagePath,
                    BloodGroup = (BloodGroup)x.BloodGroup,
                    EmergencyPerson = x.EmergencyPerson,
                    EmergencyPersonPhone = x.EmergencyPersonPhone,
                    PersonelMail = x.PersonelMail,
                    PostCode = x.PostCode
                },
                expression: x => x.Id == id
                );
            return updateDTO;
        }

        public async Task<List<PersonelCardVM>> GetActivePersonelsByCompanyId(Guid companyId)
        {
            List<PersonelCardVM> personels = await personelRepository.GetFilteredList(
                selector: x => new PersonelCardVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PersonelMail = x.PersonelMail,
                    Position = x.Position,
                    DepartmentName = x.Department.Name,
                    City = (City)x.City,
                    Adress = x.Adress,
                    MobilePhone = x.MobilePhone,
                    PhoneNumber = x.PhoneNumber,
                    ImagePath = x.ImagePath,
                    BirthDate = (DateTime)x.BirthDate
                },
                includes: x => x.Include(c => c.Department),
                expression: x => x.CompanyID == companyId && x.Status == true
                );
            return personels;
        }

        public async Task<List<PersonelCardVM>> GetPassivePersonelsByCompanyId(Guid companyId)
        {
            List<PersonelCardVM> personels = await personelRepository.GetFilteredList(
                selector: x => new PersonelCardVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PersonelMail = x.PersonelMail,
                    Position = x.Position,
                    DepartmentName = x.Department.Name,
                    City = (City)x.City,
                    Adress = x.Adress,
                    MobilePhone = x.MobilePhone,
                    PhoneNumber = x.PhoneNumber,
                    ImagePath = x.ImagePath,
                    BirthDate = (DateTime)x.BirthDate
                },
                includes: x => x.Include(c => c.Department),
                expression: x => x.CompanyID == companyId && x.Status == false
                );
            return personels;
        }

        public async Task<List<ManagerVM>> GetManagers()
        {
            var personels=await userManager.GetUsersInRoleAsync("Manager");
            List<ManagerVM> managers = new List<ManagerVM>();

            managers=mapper.Map(personels,managers);
            foreach (var item in managers)
            {
                Company company = await companyRepository.GetWhere(x => x.CompanyID == item.CompanyID);
                item.CompanyName = company.CompanyName;
            }
            return managers;
            
        }
    }
}
