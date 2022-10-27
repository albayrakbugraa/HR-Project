using BoostIK.BLL.Models.VMs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class SpendingVMValidator : AbstractValidator<SpendingVM>
    {
        public SpendingVMValidator()
        {
            RuleFor(a => a.TypeOfSpending).NotEmpty().WithMessage("Harcama tipi seçmelisiniz");
            RuleFor(a => a.CurrencyUnit).NotEmpty().WithMessage("Para birimi seçmelisiniz");
            RuleFor(a => a.Amount).NotEmpty().WithMessage("Toplam tutar giriniz").GreaterThan(0).WithMessage("Harcama miktarı 0'dan büyük olmalıdır.");
        }
    }
}
