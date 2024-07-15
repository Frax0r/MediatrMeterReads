using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByID(ulong id, CancellationToken cancellationToken);
        Task<bool> Insert(T entity);
        Task<bool> InsertList(IEnumerable<T> entities);
        void SaveChanges();
        ValueTask<T> Find(object[] keys, CancellationToken cancellationToken);
        Task CreateDbAsync(CancellationToken cancellationToken);

    }
}