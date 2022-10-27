using BoostIK.BLL.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class UpdatePersonelByManagerDTOValidator : AbstractValidator<UpdatePersonelByManagerDTO>
    {
        public UpdatePersonelByManagerDTOValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("Personel adı boş olamaz.").Length(3, 50).WithMessage("İsim en fazla 50, en az 3 karakter olmalıdır").Matches(@"^[a-zA-Z\s]+$").WithMessage("Sadece harfler giriniz");
            RuleFor(a => a.SecondName).Length(3, 50).WithMessage("İsim en fazla 50, en az 3 karakter olmalıdır").Matches(@"^[a-zA-Z\s]+$").WithMessage("Sadece harfler giriniz");
            RuleFor(a => a.LastName).NotEmpty().WithMessage("Personel soyadı boş olamaz.").Length(3, 50).WithMessage("Soyad en fazla 50, en az 3 karakter olmalıdır").Matches(@"^[a-zA-Z\s]+$").WithMessage("Sadece harfler giriniz"); ;
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email formatı hatalı");
            RuleFor(a => a.IdentificationNumber).NotEmpty().WithMessage("TCKN alanı boş olamaz.").Length(11).WithMessage("TCKN 11 hane olmalıdır").Matches("^[0-9]*$").WithMessage("TCKN sadece rakamdan oluşabilir");
            RuleFor(a => a.Gender).NotEmpty().WithMessage("Cinsiyet boş olamaz.");
            RuleFor(a => a.DepartmentID).NotEmpty().WithMessage("Personelin departmanı seçilmelidir");
            RuleFor(a => a.Position).NotEmpty().WithMessage("Personelin gorevini giriniz.").MaximumLength(100).WithMessage("En fazla 100 karater girebilirsiniz");
            RuleFor(a => a.PhoneNumber).Matches(@"^[0-9()\-\s]{10,14}$").WithMessage("Telefon formatı hatalı");
            RuleFor(a => a.MobilePhone).Matches(@"^[0-9()\-\s]{10,14}$").WithMessage("Telefon formatı hatalı");
        }
    }
}
