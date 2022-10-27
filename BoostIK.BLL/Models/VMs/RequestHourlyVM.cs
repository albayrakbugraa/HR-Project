using BoostIK.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class RequestHourlyVM
    {
        public string PersonelID { get; set; }
        public Guid CompanyID { get; set; }
        public int PermissionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; } = 1;
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public double HourCount { get {return (EndHour - StartHour).TotalHours; } }
        public string Description { get; set; }
        public RequestState State { get; set; } = RequestState.Bekliyor;
        public RestType RestType { get; set; } = RestType.Saatlik;
    }
}
