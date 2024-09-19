using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class TrackingDataForSTD
    {
        [Key]
        public int TrackingDataId { get; set; }
        [MaxLength(8)]
        public char SerialNumber { get; set; }
        public DateTime Timestamp { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Speed { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Altitude { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Odometer { get; set; }
        public bool IsOpenIgnition { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal FuelLevel { get; set; }
        public char NS { get; set; }
        public char EW { get; set; }
        public int Satellites { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal COG { get; set; }
        public bool DIN1 { get; set; }
        public bool DIN2 { get; set; }
        public bool DOUT { get; set;}
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalSpentFuel { get; set; }
        [Column(TypeName = "tinyint")]
        public byte GSM_RSSI { get;set; }
    }
}
