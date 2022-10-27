using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Enums
{
    public enum EducationLevel
    {
        [Display(Name = "Belirtilmemiş")]
        Belirtilmemiş = 1,
        [Display(Name = "İlkokul")]
        İlkokul,
        [Display(Name = "Ortaokul")]
        Ortaokul,
        [Display(Name = "Lise")]
        Lise,
        [Display(Name = "Lisans")]
        Lisans,
        [Display(Name = "Yüksek Lisans")]
        YüksekLisans,
        [Display(Name = "Doktora")]
        Doktora
    }
}
