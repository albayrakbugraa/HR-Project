using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class RequestDailyVM
    {
        public string PersonelID { get; set; }
        public Guid CompanyID { get; set; }
        public int PermissionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public string Description { get; set; }
        public RequestState State { get; set; } = RequestState.Bekliyor;
        public RestType RestType { get; set; } = RestType.Günlük;
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
    }
}
