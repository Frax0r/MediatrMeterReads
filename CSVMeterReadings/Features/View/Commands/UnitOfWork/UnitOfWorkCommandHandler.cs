using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository.Interfaces;

namespace CSVMeterReadingsAPI.Features.View.Commands.UnitOfWork
{
    public class UnitOfWorkCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UnitOfWorkCommand>
    {
        public async Task Handle(UnitOfWorkCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return;
        }

    }
}
