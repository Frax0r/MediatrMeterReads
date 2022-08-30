using AutoMapper;
using CSVMeterReadings.ViewModel;
using CSVMeterReadingsService.Features.Readings.Models;

namespace CSVMeterReadings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MeterReadingDto, MeterReadingVM>();
            CreateMap<FileUploadDto, FileUploadVM>();
        }

    }
}
