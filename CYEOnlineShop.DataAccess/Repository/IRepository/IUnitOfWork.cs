using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ISexRepository Sex { get; }
        IClthRepository Clth { get; }
        ICompanyRepository Company { get; }
        void Save();
    }
}
