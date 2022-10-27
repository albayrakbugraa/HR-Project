using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class PersonelCardVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PersonelMail { get; set; }
        public string Position { get; set; }
        public string DepartmentName { get; set; }

        public City City { get; set; }
        public string Adress { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
    }
}
