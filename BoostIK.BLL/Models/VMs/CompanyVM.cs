using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class CompanyVM
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public TradeNameType TradeName { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxNumber { get; set; }
        public City City { get; set; }
        public bool Status { get; set; }
        public int PersonelCount { get; set; }
        public string ManagerName { get; set; }
        public string LogoPath { get; set; }
        public string MailExtension { get; set; }
    }
}
