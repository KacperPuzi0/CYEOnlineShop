using CYEOnlineShop.DataAccess.Repository.IRepository;
using CYEOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.DataAccess.Repository
{
    public class ClthRepository : Repository<Clth>, IClthRepository
    {
        private ApplicationDbContext _db;

        public ClthRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Clth obj)
        {
            var objFromDb = _db.Clths.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Designer = obj.Designer;
                objFromDb.Description = obj.Description;
                objFromDb.Composition = obj.Composition;
                objFromDb.Size = obj.Size;
                objFromDb.IsAvailable = obj.IsAvailable;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.SexId = obj.SexId;

            }
        }
    }
}
