using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class DeviceVehiclesRepository: GenericRepository<DeviceVehicles> , IDevicesVehiclesRepository
    {
        private readonly DataContext _context;
        public DeviceVehiclesRepository(DataContext context) : base(context) => _context = context;
        public IQueryable<DeviceVehicles> GetDeviceVehicles(int id, bool trackchanges) => GenericReadExpression(x => x.ConnectionId == id, trackchanges);
        public IQueryable<DeviceVehicles> GetActiveDevice(bool trackchanges) => GenericReadExpression(x => x.RemoveDate == null, trackchanges);
        public IQueryable<object> GetDevicesWithVehicles()
        {
            var result = from deviceVehicle in _context.DeviceVehicles
                         join vehicle in _context.Vehicles
                         on deviceVehicle.VehicleId equals vehicle.VehicleId
                         join device in _context.Devices
                         on deviceVehicle.DeviceId equals device.DeviceId
                         where deviceVehicle.RemoveDate == null
                         select new
                         {
                             DeviceVehicle = deviceVehicle,
                             Vehicle = vehicle,
                             Device = device 
                         };
            return result;
        }
        public async Task<int> GetActiveDeviceVehicleCound()
        {
            var result = await _context.DeviceVehicles.CountAsync(dv => dv.RemoveDate == null);
            return result;
        }
    }
}
