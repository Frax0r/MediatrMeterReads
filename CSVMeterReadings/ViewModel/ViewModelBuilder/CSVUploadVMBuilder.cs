using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CSVMeterReadingsService.Features.Readings.Commands.CreateReadings;
using CSVMeterReadingsService.Features.Readings.Commands.UploadFile;
using CSVMeterReadingsService.Features.Readings.Models;
using MediatR;
using System.Linq;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal class CSVUploadVMBuilder : ViewModelBuilderBase<CSVUploadVM, IFormFile>
    {
        private readonly Mediator _mediator;
        private readonly IMapper _mapper;

        public CSVUploadVMBuilder(IMediator mediator, IMapper mapper)
        {
            _ViewModel = new ViewModel<CSVUploadVM>();
            _mediator = (Mediator)mediator;
            _mapper = mapper;
        }

        public override async Task BuildViewModelAsync()
        {
            CSVUploadDto fileUpload = await _mediator.Send(new UploadFileCommand { File = _InputObject }).ConfigureAwait(false);

            foreach (MeterReadingDto meterReading in fileUpload.MeterReadings) 
            {
                    MeterReadingDto reading = await _mediator.Send(new CreateReadingsCommand { MeterReading = meterReading }).ConfigureAwait(false);
                    meterReading.ValidationResult = reading.ValidationResult;
            }

            fileUpload.MeterReadings = fileUpload.MeterReadings.Concat(fileUpload.InvalidCSVMeterReadings);

            _ViewModel.Model = _mapper.Map<CSVUploadDto, CSVUploadVM>(fileUpload);

        }
    }
}