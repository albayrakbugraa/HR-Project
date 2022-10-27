using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class ManagerVM
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid CompanyID { get; set; }
        public string ImagePath { get; set; } = "/images/users/account-add-photo.svg";
        public Gender? Gender { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string CompanyName { get; set; }
    }
}
