using BoostIK.BLL.Models.VMs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class RequestDailyVMValidator : AbstractValidator<RequestDailyVM>
    {
        public RequestDailyVMValidator()
        {
            RuleFor(a => a.PersonelID).NotEmpty().WithMessage("Personel bilgisi girilmelidir.");
            RuleFor(a => a.CompanyID).NotEmpty().WithMessage("Şirket bilgisi eksik");
            RuleFor(a => a.PermissionID).NotEmpty().WithMessage("İzin tipi seçmelisiniz");
            RuleFor(a => a.StartDate).GreaterThanOrEqualTo(DateTime.Today.AddDays(1)).WithMessage("En erken yarın için izin talep edebilirsiniz.");
            RuleFor(a => a.EndDate).GreaterThanOrEqualTo(a => a.StartDate).WithMessage("İzin bitiş tarihi, başlangıç tarihinden önce olamaz.");
            RuleFor(a => a.DayCount).GreaterThanOrEqualTo(1).WithMessage("En az 1 gün izin girmelisiniz.").Equal(a => DayCountDiff(a.StartDate, a.EndDate)).WithMessage("Gün sayısı hatalı.");
        }

        public int DayCountDiff(DateTime start, DateTime end)
        {
            return (int)(end - start).TotalDays + 1;
        }
    }
}
