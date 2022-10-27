using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Company : IBaseEntity
    {
        public Company()
        {
            CompanyID = Guid.NewGuid();
            Departments = new HashSet<Department>();
            Personels = new HashSet<Personel>();
            PermissionLimits = new HashSet<PermissionLimit>();
            DayoffRequests = new HashSet<DayOffRequest>();
            Payments=new HashSet<Payment>();
            Spendings=new HashSet<Spending>();
        }

        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public TradeNameType TradeName { get; set; }
        public string MailExtension { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string MersisNumber { get; set; }
        public string LogoPath { get; set; } = "images/account-add-photo.svg";
        public string WebsiteAdress { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Adress { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Personel> Personels { get; set; }
        public ICollection<PermissionLimit> PermissionLimits { get; set; }
        public ICollection<DayOffRequest> DayoffRequests { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Spending> Spendings { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime MembershipEnd { get; set; }
        public bool Status { get; set; } = true;
        public string ManagerId { get; set; }
        public Personel Manager { get; set; }
    }
}
