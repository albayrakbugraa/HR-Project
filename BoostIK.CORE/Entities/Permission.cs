using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Permission : IBaseEntity
    {
        public Permission()
        {
            PermissionLimits = new HashSet<PermissionLimit>();
            DayOffRequests = new HashSet<DayOffRequest>();
        }

        public int PermissionID { get; set; }
        public string Name { get; set; }
        public int MaxDayCount { get; set; }
        public Gender Gender { get; set; }
        public ICollection<PermissionLimit> PermissionLimits { get; set; }
        public ICollection<DayOffRequest> DayOffRequests { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
    }
}
