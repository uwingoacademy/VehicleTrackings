using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class VehiclesRepository : GenericRepository<Vehicles>, IVehiclesRepository
    {
        private readonly DataContext _context;
        public VehiclesRepository(DataContext context) :base(context) => _context = context;
        public IQueryable<Vehicles> GetVehicles(int id, bool trackchanges) => GenericReadExpression(x => x.VehicleId == id, trackchanges);

    }
}
