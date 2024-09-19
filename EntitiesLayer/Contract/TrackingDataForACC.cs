using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class TrackingDataForACC
    {
        [Key]
        public int AccelerometerDataId { get; set; }
        public Devices Devices { get; set; }
        [ForeignKey("Devices")]
        public int DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        [Column(TypeName = "decimal(6,3)")]
        public decimal AccX { get; set; }
        [MaxLength(8)]
        public char SerialNumber { get; set; }
        [Column(TypeName = "decimal(6,3)")]
        public decimal AccY { get; set; }
        [Column(TypeName = "decimal(6,3)")]
        public decimal AccZ { get; set; }
        public DateTime DateTime { get; set; }
        [Column(TypeName = "decimal(11,6)")]
        public decimal Latitude { get; set; }
        public char NS { get; set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Longitude { get; set; }
        public char EW { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Altitude { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Speed { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal COG { get; set; }
        public bool IGN { get; set; }
    }
}
