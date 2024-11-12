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
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DataAccessLayer
{
    public class DataContext: IdentityDbContext<User, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Devices> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeviceVehicles> DeviceVehicles { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<DriverVehicle> DriverVehicles { get; set; }
        public DbSet<Packets> Packets { get; set; }
        public DbSet<PacketContent> PacketContents { get; set; }
        public DbSet<TrackingDataForSTD> TrackingDataForSTDs { get; set; }
        public DbSet<TrackingDataForACC> TrackingDataForACCs { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<PeriodicMaintenance> PeriodicMaintenances { get; set; }

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
