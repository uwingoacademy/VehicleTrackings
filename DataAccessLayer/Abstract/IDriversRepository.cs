using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDriversRepository : IGenericRepostory<Drivers>
    {
        IQueryable<Drivers> GetDrivers(int id, bool trackchanges);
    }
}
