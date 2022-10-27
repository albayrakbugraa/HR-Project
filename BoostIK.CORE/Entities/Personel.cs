using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Personel : IdentityUser, IBaseEntity
    {
        public Personel()
        {
            DayOffRequests = new HashSet<DayOffRequest>();
            Payments = new HashSet<Payment>();
            Spendings = new HashSet<Spending>(); 
            isPasswordChanged = false;
        }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? PersonelMail { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? Position { get; set; }
        public Guid? DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid? CompanyID { get; set; }
        public Company Company { get; set; }
        public decimal? Salary { get; set; }
        public City? City { get; set; }
        public string? Adress { get; set; }
        public string? PostCode { get; set; }
        public string? MobilePhone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public string? ImagePath { get; set; } = "/images/users/account-add-photo.svg";
        public Gender? Gender { get; set; }
        public int? AnnualLeave { get; set; }
        public int? RemaningAnnualLeave { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public SpouseEmploymentState? SpouseEmploymentState { get; set; }
        public DegreeOfDisability? DegreeOfDisability { get; set; }
        public int? ChildrenCount { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public string? EmergencyPerson { get; set; }
        public string? EmergencyPersonPhone { get; set; }
        public ICollection<DayOffRequest> DayOffRequests { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Spending> Spendings { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? IsWorking { get; set; } = true;
        public bool Status { get; set; }
        public string? IBAN { get; set; }
        public bool isPasswordChanged { get; set; }
    }
}
