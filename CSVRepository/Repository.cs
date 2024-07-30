using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Repository.DbContext;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        public Repository(IConfiguration configuration) 
        {
            _context = new ApplicationDbContext(configuration.GetConnectionString("default"));
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _entities.AsEnumerable();

        public async Task<T> GetByIDAsync(ulong id, CancellationToken cancellationToken) => await _entities.FindAsync([id], cancellationToken);

        public async Task<T> Find(object[] keys, CancellationToken cancellationToken) => await _entities.FindAsync(keys, cancellationToken);

        public async Task<bool> Insert(T entity)
        {
            if(entity == null) return false;

            await _entities.AddAsync(entity);
           
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> InsertList(IEnumerable<T> entities) 
        {
            _context.AddRange(entities);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        // Will create CustomerAccountsDB if not exists on server
        public async Task CreateDbAsync(CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
