using AutoMapper;
using CSVMeterReadings.ViewModel;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadings.AutoMapper
{
    internal class MappingProfile : Profile
    {
        internal MappingProfile()
        {
            CreateMap<MeterReadingDto, MeterReadingVM>();
            CreateMap<FileUploadDto, CSVUploadVM>();
        }

    }
}
