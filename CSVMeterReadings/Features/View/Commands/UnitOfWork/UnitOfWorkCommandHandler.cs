using System.Threading;
using System.Threading.Tasks;
using CSVMeterReadings.Features.View.Commands.UnitOfWork;
using MediatR;
using Repository.Interfaces;

namespace CSVMeterReadings.Features.View.Commands.UploadCSV
{
    public class UnitOfWorkCommandHandler : IRequestHandler<UnitOfWorkCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UnitOfWorkCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.SaveChangesAsync();
            return new Unit();
        }

    }
}
