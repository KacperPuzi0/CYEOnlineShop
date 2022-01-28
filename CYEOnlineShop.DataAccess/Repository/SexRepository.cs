using CYEOnlineShop.DataAccess.Repository.IRepository;
using CYEOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.DataAccess.Repository
{
    public class SexRepository : Repository<Sex>, ISexRepository
    {
        private ApplicationDbContext _db;

        public SexRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Add(Sex sex)
        {
            throw new NotImplementedException();
        }

        public void Update(Sex obj)
        {
            _db.Sexes.Update(obj);
        }
    }
}
