using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CSVMeterReadings.AutoMapper;
using CSVMeterReadingsService;
using CSVMeterReadingsService.AutoMapper;
using Repository;
using CSVMeterReadings;
using Microsoft.Extensions.Configuration;
using Repository.DbContext;

namespace ProtoType.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);            
            services.AddApplication();
            services.AddUIServices();           

            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new ServiceMappingProfile());
            }).CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            app.UseExceptionHandler("/error");

            app.UseStatusCodePagesWithRedirects("/Error/Http?statusCode={0}");

            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();                       

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {              
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=CSVUpload}/{action=Index}/{id?}",
                defaults: new { controller = "CSVUpload", action = "Index" });
            }
            );

            context.Database.EnsureCreated();
        }
    }
}
