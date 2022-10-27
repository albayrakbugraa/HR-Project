using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class PersonelRepository : BaseRepository<Personel> , IPersonelRepository
    {
        public PersonelRepository(AppDbContext db) : base(db)
        {
        }
    }
}
