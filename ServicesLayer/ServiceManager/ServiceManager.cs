using AutoMapper;
using DataAccessLayer.Manager;
using Microsoft.Extensions.Logging;
using ServicesLayer.Abstract;
using ServicesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDevicesService> _devicesService;
        private readonly Lazy<IPeriodicMaintenanceService> _periodicMaintenanceService;
        private readonly Lazy<IDeviceVehiclesService> _deviceVehiclesService;
        private readonly Lazy<IDriversService> _driversService;
        private readonly Lazy<IDriverVehicleService> _driversVehiclesService;
        private readonly Lazy<IPacketsService> _packetService;
        private readonly Lazy<IPacketContentService> _packetContentService;
        private readonly Lazy<ITrackingDataForACCService> _trackingDataForACCService;
        private readonly Lazy<ITrackingDataForSTDService> _trackingDataForSTDService;
        private readonly Lazy<IVehiclesService> _vehiclesService;
        public ServiceManager(IRepositoryManager repository,IMapper mapper,ILogger<DevicesService> loggerDevices , ILogger<PeriodicMaintenanceService> loggerPeriodicMaintenance, ILogger<VehiclesService> loggerVehicles, ILogger<TrackingDataForSTDService> loggerTrackingDataForSTD, ILogger<TrackingDataForACCService> loggerTrackingDataForACC, ILogger<DeviceVehiclesService> loggerDeviceVehicles , ILogger<DriversService> loggerDrivers , ILogger<DriverVehicleService> loggerDriverVehicle, ILogger<PacketsService> loggerPackets , ILogger<PacketContentService> loggerPacketContent)
        {
           _devicesService = new Lazy<IDevicesService>(()=> new DevicesService(repository, mapper , loggerDevices));
            _periodicMaintenanceService = new Lazy<IPeriodicMaintenanceService>(() => new PeriodicMaintenanceService(repository, mapper, loggerPeriodicMaintenance));
            _deviceVehiclesService = new Lazy<IDeviceVehiclesService>(() => new DeviceVehiclesService(repository, mapper, loggerDeviceVehicles));
            _driversService = new Lazy<IDriversService>(() => new DriversService(repository,mapper, loggerDrivers));
            _driversVehiclesService = new Lazy<IDriverVehicleService>(() => new DriverVehicleService(repository,mapper, loggerDriverVehicle));
            _packetService = new Lazy<IPacketsService>(() => new PacketsService(repository,loggerPackets,mapper));
            _packetContentService = new Lazy<IPacketContentService>(() =>new PacketContentService(repository,mapper, loggerPacketContent));
            _trackingDataForACCService = new Lazy<ITrackingDataForACCService>(() => new TrackingDataForACCService(repository,mapper, loggerTrackingDataForACC));
            _trackingDataForSTDService = new Lazy<ITrackingDataForSTDService>(() => new TrackingDataForSTDService(repository, loggerTrackingDataForSTD, mapper));
            _vehiclesService = new Lazy<IVehiclesService>(() => new VehiclesService(repository, loggerVehicles, mapper));
        }
        public IPeriodicMaintenanceService periodicMaintenance => _periodicMaintenanceService.Value;
        public IDevicesService devicesService => _devicesService.Value;
        public IDeviceVehiclesService deviceVehiclesService => _deviceVehiclesService.Value;
        public IDriversService driversService => _driversService.Value;
        public IDriverVehicleService driverVehicleService => _driversVehiclesService.Value;
        public IPacketsService packetsService => _packetService.Value;
        public IPacketContentService packetContentService => _packetContentService.Value;
        public ITrackingDataForACCService trackingDataForACCService => _trackingDataForACCService.Value;
        public ITrackingDataForSTDService trackingDataForSTDService => _trackingDataForSTDService.Value;
        public IVehiclesService vehiclesService => _vehiclesService.Value;
    }
}
