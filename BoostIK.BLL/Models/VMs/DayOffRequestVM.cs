using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class DayOffRequestVM
    {
        public Guid DayOffRequestID { get; set; }
        public string PersonelID { get; set; }
        public Guid CompanyID { get; set; }
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public double? HourCount { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime CreationDate { get; set; } 
        public string Description { get; set; }
        public RequestState State { get; set; } 
        public RestType RestType { get; set; } 
        public string FilePath { get; set; }
        public string RefuseDescription { get; set; }
        public string PersonelName { get; set; }

    }
}
