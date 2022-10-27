using AutoMapper;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.DayOffRequestRepository
{
    public class DayOffRequestService : IDayOffRequestService
    {
        private readonly IDayOffRequestRepository dayOffRequestRepository;
        private readonly IMapper mapper;

        public DayOffRequestService(IDayOffRequestRepository dayOffRequestRepository, IMapper mapper)
        {
            this.dayOffRequestRepository = dayOffRequestRepository;
            this.mapper = mapper;
        }
        public async Task<bool> AddNewDailyRequest(RequestDailyVM model)
        {
            DayOffRequest dor = new DayOffRequest();
            dor = mapper.Map(model, dor);
            var result =await dayOffRequestRepository.Create(dor);
            return result;
        }

        public async Task<bool> AddNewHourlyRequest(RequestHourlyVM model)
        {
            DayOffRequest dor = new DayOffRequest();
            dor = mapper.Map(model, dor);
            var result= await dayOffRequestRepository.Create(dor);
            return result;
        }

        public async Task<bool> DeleteRequestInDatabase(Guid id)
        {
            DayOffRequest dayOffRequest = await dayOffRequestRepository.GetWhere(x => x.DayOffRequestID == id);
            if (dayOffRequest==null) return false;
            else if(dayOffRequest.State != RequestState.Bekliyor) return false;
            return await dayOffRequestRepository.DeleteRequestInDatabase(dayOffRequest);
        }

        public async Task<List<DayOffRequestVM>> GetAllDayOffRequest(Guid companyId)
        {
            var dayOffRequestVMs = await dayOffRequestRepository.GetFilteredList(
                 selector: x => new DayOffRequestVM
                 {
                     DayOffRequestID = x.DayOffRequestID,
                     PermissionID = x.PermissionID,
                     PermissionName = x.Permission.Name,
                     CompanyID = x.CompanyID,
                     PersonelID = x.PersonelID,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     DayCount = x.DayCount,
                     StartHour = x.StartHour,
                     EndHour = x.EndHour,
                     HourCount = x.HourCount,
                     ReplyDate = x.ReplyDate,
                     CreationDate = x.CreationDate,
                     Description = x.Description,
                     State = x.State,
                     RestType = x.RestType,
                     FilePath = x.FilePath,
                     RefuseDescription = x.RefuseDescription,
                     PersonelName=x.Personel.FirstName + " " + x.Personel.LastName                     
                 },
                expression: x => x.CompanyID==companyId && x.Status == true && x.State==RequestState.Bekliyor,
                orderBy: x => x.OrderByDescending(x => x.CreationDate),
                includes: x => x.Include(c => c.Permission).Include(c=>c.Personel)
                );
            return dayOffRequestVMs;
        }

        public async Task<List<DayOffRequestVM>> GetDayOffRequestByPersonelID(string id)
        {
            var dayOffRequestVM = await dayOffRequestRepository.GetFilteredList(
                selector: x => new DayOffRequestVM
                {
                    DayOffRequestID = x.DayOffRequestID,
                    PermissionID = x.PermissionID,
                    PermissionName = x.Permission.Name,
                    CompanyID = x.CompanyID,
                    PersonelID = x.PersonelID,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DayCount = x.DayCount,
                    StartHour = x.StartHour,
                    EndHour = x.EndHour,
                    HourCount = x.HourCount,
                    ReplyDate = x.ReplyDate,
                    CreationDate = x.CreationDate,
                    Description = x.Description,    
                    State = x.State,
                    RestType = x.RestType,
                    FilePath = x.FilePath,
                    RefuseDescription=x.RefuseDescription
                },
                expression: x => x.PersonelID == id && x.Status  == true,
                orderBy : x=> x.OrderByDescending(x=>x.CreationDate),
                includes: x => x.Include(c => c.Permission)
                );
            return dayOffRequestVM;
        }
    }
}
