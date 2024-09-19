using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class DriversRepository :GenericRepository<Drivers>, IDriversRepository
    {
        private readonly DataContext _context;
        public DriversRepository(DataContext context):base(context) => _context = context;
        public IQueryable<Drivers> GetDrivers(int id, bool trackchanges) => GenericReadExpression(x => x.DriverId == id, trackchanges);

    }
}
