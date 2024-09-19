using ServicesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServiceManager
{
    public interface IServiceManager
    {
        IPeriodicMaintenanceService periodicMaintenance { get; }
        IDevicesService devicesService { get; }
        IDeviceVehiclesService deviceVehiclesService { get; }
        IDriversService driversService { get; }
        IDriverVehicleService driverVehicleService { get; }
        IPacketsService packetsService { get; }
        IPacketContentService packetContentService { get; }
        ITrackingDataForACCService trackingDataForACCService { get; }
        ITrackingDataForSTDService trackingDataForSTDService { get; }
        IVehiclesService vehiclesService { get; }
    }
}
