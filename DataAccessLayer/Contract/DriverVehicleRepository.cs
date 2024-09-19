using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class DriverVehicleRepository : GenericRepository<DriverVehicle>, IDriverVehicleRepository
    {
        private readonly DataContext _context;
        public DriverVehicleRepository(DataContext context):base(context)=> _context = context;
        public IQueryable<DriverVehicle> GetDriverVehicle(int id, bool trackchanges) => GenericReadExpression(x => x.DriverVehicleId == id, trackchanges);

    }
}
