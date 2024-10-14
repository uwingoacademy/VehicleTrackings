using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDevicesVehiclesRepository :IGenericRepostory<DeviceVehicles>
    {
        IQueryable<DeviceVehicles> GetDeviceVehicles(int id, bool trackchanges);
        IQueryable<DeviceVehicles> GetActiveDevice(bool trackchanges);
        IQueryable<object> GetDevicesWithVehicles();
    }
}
