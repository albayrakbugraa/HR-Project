using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.DTOs.PermissionLimit
{
    public class PermissionLimitDTO
    {
        public int PermissionLimitID { get; set; }
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public Guid CompanyID { get; set; }
        public int MaxDayCount { get; set; }
        public Gender Gender { get; set; }
    }
}
