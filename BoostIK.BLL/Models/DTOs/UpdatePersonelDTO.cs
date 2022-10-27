
using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.DTOs
{
    public class UpdatePersonelDTO
    {
        public string Id { get; set; }
        public string PersonelMail { get; set; }
        public City City { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string ImagePath { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string EmergencyPerson { get; set; }
        public string EmergencyPersonPhone { get; set; }
        public IFormFile newPhoto { get; set; }
    }
}
