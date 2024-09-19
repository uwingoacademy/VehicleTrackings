using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class TrackingDataForACCDTO
    {
        public int AccelerometerDataId { get; set; }
        public int DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal AccX { get; set; }
        [MaxLength(8)]
        public char SerialNumber { get; set; }
        public decimal AccY { get; set; }
        public decimal AccZ { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Latitude { get; set; }
        public char NS { get; set; }
        public decimal Longitude { get; set; }
        public char EW { get; set; }
        public decimal Altitude { get; set; }
        public decimal Speed { get; set; }
        public decimal COG { get; set; }
        public bool IGN { get; set; }
    }
}
