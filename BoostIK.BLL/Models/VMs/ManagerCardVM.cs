using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class ManagerCardVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; } 
        public string ImagePath { get; set; }
        public string CompanyName { get; set; }
    }
}
