using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
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

    }
}
