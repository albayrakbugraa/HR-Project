
using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.DTOs
{
    public class UpdatePersonelByManagerDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? PersonelMail { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string? MobilePhone { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? Position { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
        public decimal? Salary { get; set; }
        public City? City { get; set; }
        public string? Adress { get; set; }
        public string? PostCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public string? ImagePath { get; set; } = "images/account-add-photo.svg";
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
        public string? IBAN { get; set; }
        public bool IsWorking { get; set; } 
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }

}
