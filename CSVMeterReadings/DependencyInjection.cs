﻿using Microsoft.Extensions.DependencyInjection;
using CSVMeterReadings.ViewModel.ViewModelBuilder;
using CSVMeterReadings.ViewModel;
using Microsoft.AspNetCore.Http;
using CSVMeterReadings.Presenter;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace CSVMeterReadings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
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
