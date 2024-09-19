using DataAccessLayer.Abstract;
using DataAccessLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly Lazy<IDevicesRepository> _devicesRepository;
        private readonly Lazy<IPeriodicMaintenanceRepository> _periodicMaintenanceRepository;
        private readonly Lazy<IDevicesVehiclesRepository> _devicesVehiclesRepository; 
        private readonly Lazy<IDriversRepository> _driversRepository;
        private readonly Lazy<IDriverVehicleRepository> _vehiclesVehicleRepository;
        private readonly Lazy<IPacketContentRepository> _packetContentRepository;
        private readonly Lazy<IPacketsRepository> _packetsRepository;
        private readonly Lazy<ITrackingDataForAccRepository> _trackingDataForAccRepository;
        private readonly Lazy<ITrackingDataForSTDRepository> _trackingDataForSTDRepository;
        private readonly Lazy<IVehiclesRepository> _vehiclesRepository;
        public RepositoryManager(DataContext context)
        {
            _context = context;
            _periodicMaintenanceRepository = new Lazy<IPeriodicMaintenanceRepository>(new PeriodicMaintenanceRepository(_context));
            _devicesRepository = new Lazy<IDevicesRepository>(new DevicesRepository(_context));
            _devicesVehiclesRepository = new Lazy<IDevicesVehiclesRepository>(new DeviceVehiclesRepository(_context));
            _driversRepository = new Lazy<IDriversRepository>(new DriversRepository(_context));
            _vehiclesVehicleRepository = new Lazy<IDriverVehicleRepository>(new DriverVehicleRepository(_context));
            _packetContentRepository = new Lazy<IPacketContentRepository>(new PacketContentRepository(_context));
            _packetsRepository = new Lazy<IPacketsRepository>(new PacketsRepository(_context));
            _trackingDataForAccRepository = new Lazy<ITrackingDataForAccRepository>(new TrackingDataForAccRepository(_context));
            _trackingDataForSTDRepository = new Lazy<ITrackingDataForSTDRepository>(new TrackingDataForSTDRepository(_context));
            _vehiclesRepository = new Lazy<IVehiclesRepository>(new VehiclesRepository(_context));
        }
        public IPeriodicMaintenanceRepository PeriodicMaintenance => _periodicMaintenanceRepository.Value;
        public IDevicesRepository Devices => _devicesRepository.Value;
        public IDevicesVehiclesRepository DevicesVehiclesRepository => _devicesVehiclesRepository.Value;
        public IDriversRepository DriversRepository => _driversRepository.Value;
        public IDriverVehicleRepository DriverVehicleRepository => _vehiclesVehicleRepository.Value;
        public IPacketContentRepository PacketContentRepository => _packetContentRepository.Value;
        public IPacketsRepository PacketsRepository => _packetsRepository.Value;
        public ITrackingDataForAccRepository TrackingDataForAccRepository => _trackingDataForAccRepository.Value;
        public ITrackingDataForSTDRepository TrackingDataForSTDRepository => _trackingDataForSTDRepository.Value;
        public IVehiclesRepository VehiclesRepository => _vehiclesRepository.Value;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
