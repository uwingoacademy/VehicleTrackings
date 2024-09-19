using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IDriverVehicleService
    {
        DriverVehicleDTO GetByIdDriverVehicle(int id);
        Task<IEnumerable<DriverVehicleDTO>> GetAllDriverVehicle();
        Task<DriverVehicleDTO> CreateDriverVehicle(DriverVehicleDTO driverVehicle);
        void UpdateDriverVehicle(DriverVehicleDTO driverVehicle);
        void DeleteDiverVehicle(int id);
    }
}
