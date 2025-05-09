using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Repository.DbContext;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {            
               _context = context;
               _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _entities.AsQueryable();

        public async Task<T> GetByIDAsync(ulong id, CancellationToken cancellationToken) => await _entities.FindAsync([id], cancellationToken);

        public async Task<T> FindAsync(object[] keys, CancellationToken cancellationToken) => await _entities.FindAsync(keys, cancellationToken);

        public async Task InsertAsync(T entity)
        {
            if(entity == null) return;

            await _entities.AddAsync(entity);

        }

    }
}
