using AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Personel, PersonelCardVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, ManagerCardVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, UpdatePersonelByManagerDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, UpdatePersonelDTO>().ReverseMap();
            CreateMap<Personel, CreatePersonelDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, CreateManagerDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, AdminCardVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, UpdateAdminDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Personel, ManagerVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<UpdatePersonelByManagerDTO, UpdatePersonelDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<DayOffRequest, RequestDailyVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<DayOffRequest, RequestHourlyVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Spending, SpendingVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Payment, PaymentVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Company, CreateCompanyDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Company, CompanyVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
        }

    }
}
