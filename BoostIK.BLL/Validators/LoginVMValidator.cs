using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Models.VMs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(a => a.Email).NotEmpty().WithMessage("Lütfen mail adresi giriniz.").EmailAddress().WithMessage("Email formatı hatalı !");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Lütfen şifre giriniz.");
        }

    }
}
