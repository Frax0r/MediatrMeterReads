using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadingsService.Features.Readings.Commands.CreateReadings;
using CSVMeterReadingsService.Features.Readings.Commands.UploadFile;
using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    public class CSVUploadVMBuilder : ViewModelBuilder<FileUploadVM, IFormFile>
    {
        private readonly Mediator _mediator;
        private readonly IMapper _mapper;

        public CSVUploadVMBuilder(Mediator mediator, IMapper mapper)
        {
            _ViewModel = new ViewModel<FileUploadVM>();
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task BuildViewModel()
        {
            FileUploadDto fileUpload = await _mediator.Send(new UploadFileCommand { File = _InputObject }).ConfigureAwait(false);

            foreach (MeterReadingDto meterReading in fileUpload.MeterReadings) 
            {
                MeterReadingDto reading = await _mediator.Send(new CreateReadingsCommand { MeterReading = meterReading }).ConfigureAwait(false);
                meterReading.ValidationResult = reading.ValidationResult;
            }

            _ViewModel.Core = _mapper.Map<FileUploadDto, FileUploadVM>(fileUpload);

        }
    }
}