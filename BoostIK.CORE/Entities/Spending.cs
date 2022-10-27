using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Spending : IBaseEntity
    {
        public Spending()
        {
            SpendingID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Status = true;
            State = RequestState.Bekliyor;
        }
        public Guid SpendingID { get; set; }
        public decimal Amount { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public TypeOfSpending TypeOfSpending { get; set; }
        public RequestState State { get; set; }
        public Personel Personel { get; set; }
        public string PersonelID { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public DateTime SpendingDate { get; set; }
        public DateTime CreationDate {get; set;}
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
        public string RefuseDescription { get; set; }
    }
}
