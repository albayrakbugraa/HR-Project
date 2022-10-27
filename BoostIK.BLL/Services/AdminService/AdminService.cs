using AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IPersonelRepository personelRepository;
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public AdminService(IPersonelRepository personelRepository, UserManager<Personel> userManager, IMapper mapper)
        {
            this.personelRepository = personelRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<AdminCardVM> GetAdminCard(string adminId)
        {
            AdminCardVM adminCard = await personelRepository.GetFilteredFirstOrDefault(
                selector: x => new AdminCardVM
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImagePath = x.ImagePath,
                    PhoneNumber = x.PhoneNumber,
                    Position = x.Position
                },
                expression: x => x.Id == adminId
                );
            return adminCard;
        }

        public async Task<UpdateAdminDTO> GetAdminEditInfo(string adminId)
        {
            UpdateAdminDTO updateAdmin = await personelRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdateAdminDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName= x.FirstName,
                    LastName= x.LastName,
                    ImagePath= x.ImagePath,
                    PhoneNumber = x.PhoneNumber
                },
                expression: x => x.Id == adminId
                );
            return updateAdmin;
        }

        public async Task<bool> UpdateAdmin(UpdateAdminDTO model)
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
    }
}
