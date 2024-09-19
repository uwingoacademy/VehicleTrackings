using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class Drivers
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverCode { get; set; }
    }
}
