using CSVMeterReadingsAPI.Presenter;
using CSVMeterReadingsAPI.ViewModel.ViewModelBuilder;
using CSVMeterReadingsAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CSVMeterReadingsAPI
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
            services.AddScoped<IViewModelBuilder<CsvUploadVM, IFormFile>, CSVUploadVMBuilder>();
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
