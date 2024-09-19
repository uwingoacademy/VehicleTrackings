using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IDeviceVehiclesService
    {
        Task<DeviceVehiclesDTO> GetByIdDeviceVehicle(int id);
        Task<IEnumerable<DeviceVehiclesDTO>> GetAllDeviceVehicles();
        Task<DeviceVehiclesDTO> CreateDeviceVehicles(DeviceVehiclesDTO deviceVehicles);
        void UpdateDeviceVehicles(DeviceVehiclesDTO deviceVehicles);
        void DeleteDeviceVehicles(int id);
    }
}
