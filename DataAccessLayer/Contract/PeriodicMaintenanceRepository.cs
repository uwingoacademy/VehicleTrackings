using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class PeriodicMaintenanceRepository : GenericRepository<PeriodicMaintenance>, IPeriodicMaintenanceRepository
    {
        private readonly DataContext _options;
        public PeriodicMaintenanceRepository(DataContext options) : base(options)
        {
            _options = options;
        }
        public IQueryable<PeriodicMaintenance> GetPeriodicMaintenance(int id, bool trackchanges) => GenericReadExpression(x => x.PeriodicMaintenanceId == id, trackchanges);
    }
}
