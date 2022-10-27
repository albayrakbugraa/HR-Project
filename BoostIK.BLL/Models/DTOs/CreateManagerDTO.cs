using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.DTOs
{
    public class CreateManagerDTO
    {
        public CreateManagerDTO()
        {
            Password = Guid.NewGuid().ToString().Substring(0, 8);
        }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string Password { get; }
        public string Email { get; set; }
        public string UserName { get => Email; }
        public string Position { get; set; } = "Şirket Yöneticisi";
        public Guid CompanyID { get; set; }
        public string ImagePath { get; set; } = "/images/users/account-add-photo.svg";
        public Gender? Gender { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsWorking { get; set; } = true;
        public bool Status { get; set; } = true;
        public bool isPasswordChanged { get; set; } = true;
        public string CompanyName { get; set; }
    }
}
