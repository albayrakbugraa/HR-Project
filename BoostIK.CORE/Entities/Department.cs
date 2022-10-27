using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.CORE.Entities
{
    public class Department : IBaseEntity
    {
        public Department()
        {
            Personels = new HashSet<Personel>();
            DepartmentID = Guid.NewGuid();
        }

        public Guid DepartmentID { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public Guid CompanyID { get; set; }
        public ICollection<Personel> Personels { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
    }
}
