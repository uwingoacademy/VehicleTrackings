using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Contract;
using DataAccessLayer.Manager;
using EntitiesLayer.Contract;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Abstract;
using ServicesLayer.Contract;
using ServicesLayer.ServiceManager;

namespace Uwingo.Extencion
{
    public static class ServiceExtencion 
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfiguerRepostoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IPeriodicMaintenanceRepository, PeriodicMaintenanceRepository>();
            services.AddScoped<IDevicesRepository, DevicesRepository>();
            services.AddScoped<IDevicesVehiclesRepository, DeviceVehiclesRepository>();
            services.AddScoped<IDriversRepository, DriversRepository>();
            services.AddScoped<IDriverVehicleRepository,DriverVehicleRepository>();
            services.AddScoped<IPacketContentRepository, PacketContentRepository>();
            services.AddScoped<IPacketsRepository,PacketsRepository>();
            services.AddScoped<ITrackingDataForAccRepository,TrackingDataForAccRepository>();
            services.AddScoped<ITrackingDataForSTDRepository,TrackingDataForSTDRepository>();
            services.AddScoped<IVehiclesRepository,VehiclesRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            //BaseGenericRepositoryReferance
            services.AddScoped<IGenericRepostory<PeriodicMaintenance>, GenericRepository<PeriodicMaintenance>>();
            services.AddScoped<IGenericRepostory<Devices>,GenericRepository<Devices>>();
            services.AddScoped<IGenericRepostory<DeviceVehicles>, GenericRepository<DeviceVehicles>>();
            services.AddScoped<IGenericRepostory<Drivers>, GenericRepository<Drivers>>();
            services.AddScoped<IGenericRepostory<DriverVehicle>, GenericRepository<DriverVehicle>>();
            services.AddScoped<IGenericRepostory<PacketContent>, GenericRepository<PacketContent>>();
            services.AddScoped<IGenericRepostory<Packets>, GenericRepository<Packets>>();
            services.AddScoped<IGenericRepostory<TrackingDataForACC>, GenericRepository<TrackingDataForACC>>();
            services.AddScoped<IGenericRepostory<TrackingDataForSTD>, GenericRepository<TrackingDataForSTD>>();
            services.AddScoped<IGenericRepostory<Vehicles>, GenericRepository<Vehicles>>();
        }
        public static void ConfiguerServiceManager(this IServiceCollection services) 
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IDevicesService, DevicesService>();
            services.AddScoped<IDeviceVehiclesService, DeviceVehiclesService>();
            services.AddScoped<IDriversService, DriversService>();
            services.AddScoped<IDriverVehicleService,DriverVehicleService>();
            services.AddScoped<IPacketContentService, PacketContentService>();
            services.AddScoped<IPacketsService, PacketsService>();
            services.AddScoped<ITrackingDataForACCService, TrackingDataForACCService>();
            services.AddScoped<ITrackingDataForSTDService, TrackingDataForSTDService>();
            services.AddScoped<IVehiclesService, VehiclesService>();
            services.AddScoped<IPeriodicMaintenanceService, PeriodicMaintenanceService>();
            
        }
    }
}
