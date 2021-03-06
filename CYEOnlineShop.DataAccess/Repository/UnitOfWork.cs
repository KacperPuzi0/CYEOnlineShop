using CYEOnlineShop.DataAccess.Repository.IRepository;
using CYEOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Sex = new SexRepository(_db);
            Clth = new ClthRepository(_db);
            Company = new CompanyRepository(_db);   
        }
        public ICategoryRepository Category { get; private set; }

        public ISexRepository Sex {get; private set; }
        public IClthRepository Clth { get; private set; }

        public ICompanyRepository Company { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
