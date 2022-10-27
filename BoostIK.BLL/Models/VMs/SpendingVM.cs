using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class SpendingVM
    {
        public Guid SpendingID { get; set; }
        public decimal Amount { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
        public TypeOfSpending TypeOfSpending { get; set; }
        public RequestState State { get; set; } = RequestState.Bekliyor;
        public Personel Personel { get; set; }
        public string PersonelID { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public DateTime SpendingDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string RefuseDescription { get; set; }

    }
}
