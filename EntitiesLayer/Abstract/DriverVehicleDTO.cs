using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class DriverVehicleDTO
    {
        public int DriverVehicleId { get; set; }
        public int DriversId { get; set; }
        public int VehicleId { get; set; }
        public DateTime IdentificationDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
