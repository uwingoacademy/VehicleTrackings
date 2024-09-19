using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDriverVehicleRepository :IGenericRepostory<DriverVehicle>
    {
        IQueryable<DriverVehicle> GetDriverVehicle(int id, bool trackchanges);
    }
}
