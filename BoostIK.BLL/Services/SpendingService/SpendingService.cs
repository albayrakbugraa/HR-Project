using AutoMapper;
using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Services.SpendingService
{
    public class SpendingService : ISpendingService
    {
        private readonly IMapper mapper;
        private readonly ISpendingRepository spendingRepository;

        public SpendingService(IMapper mapper,ISpendingRepository spendingRepository)
        {
            this.mapper = mapper;
            this.spendingRepository = spendingRepository;
        }
        public async Task<bool> AddNewSpendingRequest(SpendingVM model)
        {
            Spending spending = new Spending();
            spending = mapper.Map(model, spending);
            var result = await spendingRepository.Create(spending);
            return result;
        }

        public async Task<bool> DeleteSpendingInDatabase(Guid id)
        {
            Spending spending = await spendingRepository.GetWhere(a => a.SpendingID == id);
            if (spending == null) return false;
            else if (spending.State != RequestState.Bekliyor) return false;
            return await spendingRepository.DeleteRequestInDatabase(spending);
        }

        public async Task<List<SpendingVM>> GetSpendingByPersonelID(string id)
        {
            var spendingVM = await spendingRepository.GetFilteredList(
                selector: x => new SpendingVM
                {
                    SpendingID = x.SpendingID,
                    Amount = x.Amount,
                    CurrencyUnit = x.CurrencyUnit,
                    Description = x.Description,
                    FilePath = x.FilePath,
                    TypeOfSpending = x.TypeOfSpending,
                    State = x.State,
                    CompanyID = x.CompanyID,
                    SpendingDate = x.SpendingDate,
                    CreationDate = x.CreationDate,
                    UpdateDate = x.UpdateDate,
                    DeleteDate = x.DeleteDate,
                    RefuseDescription=x.RefuseDescription
                },
                expression: x => x.PersonelID == id && x.Status == true,
                orderBy: x => x.OrderByDescending(x => x.CreationDate));
            return spendingVM;
        }
    }
}
