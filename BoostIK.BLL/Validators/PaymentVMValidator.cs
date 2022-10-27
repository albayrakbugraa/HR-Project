using BoostIK.BLL.Models.VMs;
using BoostIK.CORE.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class PaymentVMValidator : AbstractValidator<PaymentVM>
    {
        public PaymentVMValidator()
        {
            RuleFor(a => a.CurrencyUnit).NotEmpty().WithMessage("Para birimi seçmelisiniz");
            RuleFor(a => a.Amount).NotEmpty().WithMessage("Toplam tutar giriniz").GreaterThan(0).WithMessage("Avans miktarı 0'dan büyük olmalıdır.");
            RuleFor(a => a.Description).NotEmpty().WithMessage("Lütfen açıklama giriniz");
        }
    }
}
