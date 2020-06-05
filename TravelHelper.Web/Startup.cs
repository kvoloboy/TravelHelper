using Autofac;
using AutoMapper;
using BusinessLayer.AgencyManagement.Mappings;
using BusinessLayer.CategoryManagement.Mappings;
using BusinessLayer.HotelManagement.Mappings;
using BusinessLayer.LocationsManagement.Mappings;
using BusinessLayer.OrderManagement.Mappings;
using BusinessLayer.Shared.Modules;
using BusinessLayer.TourManagement.Mappings;
using BusinessLayer.UserManagement.Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelHelper.DataAccess;
using TravelHelper.DataAccess.Context;
using TravelHelper.Identity;
using TravelHelper.Web.Mappings;

namespace TravelHelper.Web
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddDbContext<TravelHelperDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TravelHelperDbContext")));

            services.AddAutoMapper(
                typeof(AgencyProfile),
                typeof(CategoryProfile),
                typeof(HotelProfile),
                typeof(LocationProfile),
                typeof(OrderProfile),
                typeof(TourProfile),
                typeof(UserProfile),
                typeof(WebProfile)
            );
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessLayerModule());
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new IdentityModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
