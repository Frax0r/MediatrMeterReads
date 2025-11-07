using AutoMapper;
using CSVMeterReadingsAPI.ViewModel;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadingsAPI.AutoMapper
{
    internal class MappingProfile : Profile
    {
        internal MappingProfile()
        {
            CreateMap<MeterReadingDto, MeterReadingVM>();
            CreateMap<CSVUploadDto, CsvUploadVM>();
            CreateMap<ValidationDto, ValidationDtoVM>();
        }

    }
}
