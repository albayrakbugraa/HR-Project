using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoostIK.CORE.Enums
{
    public enum TradeNameType
    {
        [Display(Name = "Anonim Şirketi")]
        Anonim = 1,
        [Display(Name = "Limited Şirketi")]
        Limited,
        [Display(Name = "Şahıs Şirketi")]
        Sahis,
        [Display(Name = "Kooperatif Şirketi")]
        Kooperatif        
    }
}
