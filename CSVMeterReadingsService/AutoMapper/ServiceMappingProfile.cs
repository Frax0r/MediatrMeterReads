using AutoMapper;
using CSVMeterReadingsModels;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadingsService.AutoMapper
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<MeterReadingDto, MeterReading>();
        }

    }
}
