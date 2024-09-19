using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IPeriodicMaintenanceService
    {
        Task<IEnumerable<PeriodicMaintenanceDTO>> GetAllPeriodicMaintenance();
        Task<PeriodicMaintenanceDTO> GetByIdPeriodicMaintenance(int id);
        Task<PeriodicMaintenanceDTO> CreatePeriodicMaintenance(PeriodicMaintenanceDTO devices);
        void UpdatePeriodicMaintenance(PeriodicMaintenanceDTO devices);
        void DeletePeriodicMaintenance(int id);
    }
}
