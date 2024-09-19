using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EntitiesLayer.Contract;

namespace DataAccessLayer
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Devices> Devices { get; set; }
        DbSet<DeviceVehicles> DeviceVehicles { get; set; }
        DbSet<Drivers> Drivers { get; set; }
        DbSet<DriverVehicle> DriverVehicles { get; set; }
        DbSet<Packets> Packets { get; set; }
        DbSet<PacketContent> PacketContents { get; set; }
        DbSet<TrackingDataForSTD> TrackingDataForSTDs { get; set; }
        DbSet<TrackingDataForACC> TrackingDataForACCs { get; set; }
        DbSet<Vehicles> Vehicles { get; set; }
        DbSet<PeriodicMaintenance> PeriodicMaintenances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }
    }
}
