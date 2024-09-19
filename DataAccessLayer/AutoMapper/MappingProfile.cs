using AutoMapper;
using EntitiesLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Devices, DevicesDTO>().ReverseMap();
            CreateMap<DeviceVehicles, DeviceVehiclesDTO>().ReverseMap();
            CreateMap<Drivers, DriversDTO>().ReverseMap();
            CreateMap<DriverVehicle, DriverVehicleDTO>().ReverseMap();
            CreateMap<PacketContent, PacketContentDTO>().ReverseMap();
            CreateMap<Packets, PacketsDTO>().ReverseMap();
            CreateMap<TrackingDataForACC, TrackingDataForACCDTO>().ReverseMap();
            CreateMap<TrackingDataForSTD, TrackingDataForSTDDTO>().ReverseMap();
            CreateMap<Vehicles, VehiclesDTO>().ReverseMap();
            CreateMap<PeriodicMaintenance, PeriodicMaintenanceDTO>().ReverseMap();
        }
    }
}
