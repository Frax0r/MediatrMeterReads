using Repository.DbContext;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
