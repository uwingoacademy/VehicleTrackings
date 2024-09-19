using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class DeviceVehicles
    {
        [Key]
        public int ConnectionId { get; set; }
        public Devices Devices { get; set; }
        [ForeignKey("Devices")]
        public int DeviceId { get; set; }
        public Vehicles Vehicles { get; set; }
        [ForeignKey("Vehicles")]
        public int VehicleId { get; set; }
        public DateTime InstallDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
