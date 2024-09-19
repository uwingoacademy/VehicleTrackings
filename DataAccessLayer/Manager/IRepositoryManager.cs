using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Manager
{
    public interface IRepositoryManager
    {
        IPeriodicMaintenanceRepository PeriodicMaintenance { get; }
        IDevicesRepository Devices { get; }
        IDevicesVehiclesRepository DevicesVehiclesRepository { get; }
        IDriversRepository DriversRepository { get; }
        IDriverVehicleRepository DriverVehicleRepository { get; }
        IPacketContentRepository PacketContentRepository { get; }
        IPacketsRepository PacketsRepository { get; }
        ITrackingDataForAccRepository TrackingDataForAccRepository { get; }
        ITrackingDataForSTDRepository TrackingDataForSTDRepository { get; }
        IVehiclesRepository VehiclesRepository { get; } 
        void Save();
    }
}
