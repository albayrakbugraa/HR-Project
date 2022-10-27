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
    public class ResetPasswordDTOValidator : AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordDTOValidator()
        {
            RuleFor(a => a.Email).NotEmpty().WithMessage("Lütfen e-posta adresinizi boş geçmeyiniz.").EmailAddress().WithMessage("Lütfen uygun formatta e-posta giriniz.");
        }
    }
}
