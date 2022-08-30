using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using CSVMeterReadings.AutoMapper;
using CSVMeterReadings.Service;
using CSVMeterReadingsService;
using CSVMeterReadingsService.AutoMapper;
using Repository;

namespace ProtoType.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // This is Not Applicaiton Code this is just used to seed the database with accounts data
            CSVUploadService.SeedAccounts(configuration);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddFluentValidationAutoValidation();

            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new ServiceMappingProfile());
            }).CreateMapper();
            services.AddSingleton(mapper);

            services.AddRazorPages().AddRazorRuntimeCompilation();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseExceptionHandler("/Controllers/Error/");

            app.UseStatusCodePagesWithRedirects("/Error/Http?statusCode={0}");

            app.UseEndpoints(endpoints =>
            {              
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=CSVUpload}/{action=Index}/{id?}",
                defaults: new { controller = "CSVUpload", action = "Index" });
            }
            );
        }
    }
}
