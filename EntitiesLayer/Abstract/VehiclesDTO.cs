﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class VehiclesDTO
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public int FirstKilometer { get; set; }
        public string Plate { get; set; }
        public bool IsThereDriver { get; set; }
        public bool? IsItForRent { get; set; }
    }
}