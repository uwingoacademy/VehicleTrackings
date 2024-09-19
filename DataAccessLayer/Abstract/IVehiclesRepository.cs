using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IVehiclesRepository : IGenericRepostory<Vehicles>
    {
        IQueryable<Vehicles> GetVehicles(int id, bool trackchanges);
    }
}
