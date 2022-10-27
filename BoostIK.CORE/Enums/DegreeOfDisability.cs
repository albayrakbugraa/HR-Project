using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Enums
{
    public enum DegreeOfDisability
    {
        [Display(Name = "1.Derece")]
        Level_1 = 1,
        [Display(Name = "2.Derece")]
        Level_2,
        [Display(Name = "3.Derece")]
        Level_3
    }
}
