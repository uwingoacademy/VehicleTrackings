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
    public class DevicesRepository : GenericRepository<Devices>, IDevicesRepository
    {

        private readonly DataContext _context;
        public DevicesRepository(DataContext context) : base(context)   
        {
            _context = context;
        }
        public IQueryable<Devices> GetDevices(int id, bool trackchanges) => GenericReadExpression(x => x.DeviceId == id, trackchanges);
    }
}
