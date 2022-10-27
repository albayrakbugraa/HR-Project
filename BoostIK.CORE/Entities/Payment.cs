using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Payment : IBaseEntity
    {
        public Payment()
        {
            PaymentID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            State = RequestState.Bekliyor;
            Status=true;
        }
        public Guid PaymentID { get; set; }
        public Personel Personel { get; set; }
        public string PersonelID { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public decimal Amount { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public string Description { get; set; }
        public RequestState State { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime CreationDate {get; set;} 
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
        public string RefuseDescription { get; set; }
    }
}
