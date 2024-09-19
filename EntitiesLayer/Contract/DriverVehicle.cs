using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class DriverVehicle
    {
        [Key]
        public int DriverVehicleId { get; set; }
        public  Drivers Drivers { get; set; }
        [ForeignKey("Drivers")]
        public int DriversId { get; set; }
        public Vehicles Vehicles { get; set; }
        [ForeignKey("Vehicles")]
        public int VehicleId { get; set; }
        public DateTime IdentificationDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
