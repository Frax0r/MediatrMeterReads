using Repository.DbContext;
using Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IDisposable
    {
        public async Task SaveChangesAsync(CancellationToken cancellationToken) => await context.SaveChangesAsync(cancellationToken);
        public void Dispose() => context.Dispose();

    }

}
