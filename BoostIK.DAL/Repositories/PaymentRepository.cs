using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext db;

        public PaymentRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<bool> DeleteRequestInDatabase(Payment entity)
        {
            db.Set<Payment>().Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
