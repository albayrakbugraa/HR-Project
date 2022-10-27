using BoostIK.BLL.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class UpdatePersonelDTOValidator : AbstractValidator<UpdatePersonelDTO>
    {
        public UpdatePersonelDTOValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Güncellenecek personelin ID'si yok!");
            RuleFor(a => a.PersonelMail).EmailAddress().WithMessage("Email formatı hatalı");
            RuleFor(a => a.PhoneNumber).Matches(@"^$|^[0-9()\+\-\s]{10,16}$").WithMessage("Şirket telefonu formatı hatalı"); // boş yada pattern
            RuleFor(a => a.MobilePhone).Matches(@"^$|^[0-9()\+\-\s]{10,16}$").WithMessage("Cep telefonu formatı hatalı"); // boş yada pattern
            RuleFor(a => a.EmergencyPersonPhone).Matches(@"^$|^[0-9()\+\-\s]{10,16}$").WithMessage("Acil durum numarası formatı hatalı");
            RuleFor(a => a.EmergencyPerson).Matches(@"^$|^[a-zA-Z\s]+$").WithMessage("Acil durum kişisi adında sayı olamaz.");
            RuleFor(a => a.PostCode).Matches(@"[0-9]{5}").WithMessage("Posta kodu 5 karakter uzunluğunda sayı olmalıdır.");
        }
    }
}
