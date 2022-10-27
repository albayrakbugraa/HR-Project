using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Enums
{
    public enum BloodGroup
    {
        [Description("ARh+")] ARhPositive =1,
        [Description("ARh-")] ARhNegative,
        [Description("BRh+")] BRhPositive,
        [Description("BRh-")] BRhNegative,
        [Description("0Rh+")] ORhPositive,
        [Description("0Rh-")] ORhNegative,
    }
}
