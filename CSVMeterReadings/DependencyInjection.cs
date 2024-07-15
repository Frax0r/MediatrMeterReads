using Microsoft.Extensions.DependencyInjection;
using CSVMeterReadings.ViewModel.ViewModelBuilder;
using CSVMeterReadings.ViewModel;
using Microsoft.AspNetCore.Http;

namespace CSVMeterReadings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {           
           // services.AddScoped<IViewModelBuilder<FileUploadVM,IFormFile>, CSVUploadVMBuilder>();   
            return services;
        }
    }
}
