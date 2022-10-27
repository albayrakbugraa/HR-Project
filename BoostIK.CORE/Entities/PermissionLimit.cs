using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class PermissionLimit : IBaseEntity
    {
        public int ID { get; set; }
        public Permission Permission { get; set; }
        public int PermissionID { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public int MaxDayCount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
    }
}
