using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class PeriodicMaintenance
    {
        public int PeriodicMaintenanceId { get; set; }
        public Vehicles Vehicles { get; set; }
        [ForeignKey("Vehicles")]
        public int VehicleId { get; set; }
        public int Period { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime? NextMaintenanceDate
        {
            get
            {
                // LastMaintenanceDate ve Period varsa, tarih hesaplanıyor
                if (LastMaintenanceDate != null && Period > 0)
                {
                    return LastMaintenanceDate.AddMonths(Period);
                }

                // Veriler uygun değilse null döner
                return null;
            }
        }
    }
}
