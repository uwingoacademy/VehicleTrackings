using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class Devices
    {
        [Key]
        public int DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string PacketType { get; set; }
        public bool IsConnectedVehicles { get; set; }
    }
}
