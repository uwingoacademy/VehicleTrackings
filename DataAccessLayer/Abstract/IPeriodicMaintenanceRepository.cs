using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPeriodicMaintenanceRepository : IGenericRepostory<PeriodicMaintenance>
    {
        IQueryable<PeriodicMaintenance> GetPeriodicMaintenance(int id, bool trackchanges);
    }
}
