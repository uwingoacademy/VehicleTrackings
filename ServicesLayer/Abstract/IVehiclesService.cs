using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IVehiclesService
    {
        VehiclesDTO GetByIdVehicle(int id);
        Task<IEnumerable<VehiclesDTO>> GetAllVehicles();
        Task<VehiclesDTO> CreateVehicles(VehiclesDTO vehicles);
        void UpdateVehicles(VehiclesDTO vehicles);
        void DeleteVehicles(int id);
    }
}
