using Microsoft.Extensions.DependencyInjection;
using CSVMeterReadings.ViewModel.ViewModelBuilder;
using CSVMeterReadings.ViewModel;
using Microsoft.AspNetCore.Http;
using CSVMeterReadings.Presenter;

namespace CSVMeterReadings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {           
            services.AddScoped<IViewModelBuilder<CSVUploadVM, IFormFile>, CSVUploadVMBuilder>();
            services.AddScoped(typeof(IPresenter<, >), typeof(Presenter<, >));
            return services;
        }
    }
}
