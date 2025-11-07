using CSVMeterReadings.Presenter;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CSVMeterReadings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddDebug();
            });

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IViewModelBuilder<CSVUploadVM, IFormFile>, CSVUploadVMBuilder>();
            services.AddScoped(typeof(IPresenter<, >), typeof(Presenter<, >));
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();

            return services;
        }
    }
}
