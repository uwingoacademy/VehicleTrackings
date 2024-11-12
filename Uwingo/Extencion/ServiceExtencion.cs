using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Contract;
using DataAccessLayer.Manager;
using EntitiesLayer.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServicesLayer.Abstract;
using ServicesLayer.Contract;
using ServicesLayer.ServiceManager;
using System.Text;

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
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IDriverVehicleService,DriverVehicleService>();
            services.AddScoped<IPacketContentService, PacketContentService>();
            services.AddScoped<IPacketsService, PacketsService>();
            services.AddScoped<ITrackingDataForACCService, TrackingDataForACCService>();
            services.AddScoped<ITrackingDataForSTDService, TrackingDataForSTDService>();
            services.AddScoped<IVehiclesService, VehiclesService>();
            services.AddScoped<IPeriodicMaintenanceService, PeriodicMaintenanceService>();
            services.AddScoped<ICustomAuthorizationService, CustomAuthorizationService>();
            services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, CustomAuthorizationHandler>();

        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>
                (
                    opts =>
                    {
                        opts.Password.RequireDigit = true;
                        opts.Password.RequireLowercase = true;
                        opts.Password.RequireUppercase = true;
                        opts.Password.RequireNonAlphanumeric = true;
                        opts.Password.RequiredLength = 8;

                        opts.User.RequireUniqueEmail = true;

                    }
                ).AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddRoleManager<RoleManager<IdentityRole>>()
               .AddEntityFrameworkStores<DataContext>();


        }
        public static void ConfigureAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                using (var serviceProvider = services.BuildServiceProvider())
                {
                    var policyProviderService = serviceProvider.GetRequiredService<ICustomAuthorizationService>();
                    var requirements = policyProviderService.GetCustomRequirementsAsync().Result;

                    foreach (var requirement in requirements)
                    {
                        options.AddPolicy(requirement.ClaimValue, policy =>
                            policy.RequireClaim(requirement.ClaimType, requirement.ClaimValue));
                    }
                }
            });
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings"); 
            var secretKey = jwtSettings["SecretKey"];
            var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index"; 
                })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = configuration.GetSection("JwtSettings");
                    var secretKey = jwtSettings["SecretKey"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["ValidateIssue"],
                        ValidAudience = jwtSettings["ValidateAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };
                });
        }   
    }
}
