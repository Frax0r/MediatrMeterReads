using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CSVMeterReadingsAPI.AutoMapper;
using CSVMeterReadingsService;
using CSVMeterReadingsService.AutoMapper;
using Repository;
using Repository.DbContext;

namespace CSVMeterReadingsAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
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

        public void Configure(IApplicationBuilder app, ApplicationDbContext context)
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
            });

            context.Database.EnsureCreated();
        }
    }
}
