using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class DayOffRequestRepository : BaseRepository<DayOffRequest>, IDayOffRequestRepository
    {
        private readonly AppDbContext db;

        public DayOffRequestRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<bool> DeleteRequestInDatabase(DayOffRequest entity)
        {
            db.Set<DayOffRequest>().Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
