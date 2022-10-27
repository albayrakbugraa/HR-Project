using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class PermissionLimitRepository : BaseRepository<PermissionLimit>, IPermissionLimitRepository
    {
        public PermissionLimitRepository(AppDbContext db) : base(db)
        {
        }
    }
}
