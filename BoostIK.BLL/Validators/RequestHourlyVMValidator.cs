using BoostIK.BLL.Models.VMs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Validators
{
    public class RequestHourlyVMValidator : AbstractValidator<RequestHourlyVM>
    {
        public RequestHourlyVMValidator()
        {
            //RuleFor(a => a.PersonelID).NotEmpty().WithMessage("Personel bilgisi girilmelidir.");
            //RuleFor(a => a.CompanyID).NotEmpty().WithMessage("Şirket bilgisi eksik");
            RuleFor(a => a.StartDate).GreaterThanOrEqualTo(DateTime.Today.AddDays(1)).WithMessage("En erken yarın için izin talep edebilirsiniz.");
            RuleFor(a => a.HourCount).GreaterThanOrEqualTo(1).WithMessage("En az 1 saat izin girmelisiniz.");
            //RuleFor(a => a.PermissionID).NotEmpty().WithMessage("İzin tipi seçmelisiniz");
            RuleFor(a => a.EndHour).GreaterThan(b => b.StartHour).WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz !");
        }
    }
}
