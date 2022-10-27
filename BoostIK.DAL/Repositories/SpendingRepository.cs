using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class SpendingRepository : BaseRepository<Spending>, ISpendingRepository
    {
        private readonly AppDbContext db;

        public SpendingRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<bool> DeleteRequestInDatabase(Spending entity)
        {
            db.Set<Spending>().Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
