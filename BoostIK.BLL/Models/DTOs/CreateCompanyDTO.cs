using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.DTOs
{
    public class CreateCompanyDTO
    {
        public CreateCompanyDTO()
        {
            CompanyID = Guid.NewGuid();
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
        public City City { get; set; }
        public string Adress { get; set; }
        public IFormFile Logo { get; set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
        public bool Status { get; set; } = true;
    }
}
