using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class PeriodicMaintenanceDTO
    {
        public int PeriodicMaintenanceId { get; set; }
        public int VehicleId { get; set; }
        public int Period { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }

    }
}
