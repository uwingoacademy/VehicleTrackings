using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class DeviceVehiclesDTO
    {
        public int ConnectionId { get; set; }
        public int DeviceId { get; set; }
        public int VehicleId { get; set; }
        public DateTime InstallDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
