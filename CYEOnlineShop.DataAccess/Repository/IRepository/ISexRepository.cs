using CYEOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.DataAccess.Repository.IRepository
{
    public interface ISexRepository : IRepository<Sex>
    {
        void Update(Sex obj);
        
        
    }
}
