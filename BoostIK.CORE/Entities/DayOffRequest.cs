using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class DayOffRequest : IBaseEntity
    {
        public DayOffRequest()
        {
            DayOffRequestID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            State = RequestState.Bekliyor;
        }

        public Guid DayOffRequestID { get; set; }
        public Personel Personel { get; set; }
        public string PersonelID { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public Permission Permission { get; set; }
        public int PermissionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public double? HourCount { get; set; }
        public string Description { get; set; }
        public RequestState State { get; set; } 
        public DateTime? ReplyDate { get; set; }
        public RestType RestType { get; set; }
        public string FilePath { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; } = true;
        public string RefuseDescription { get; set; }
    }
}
