using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIDAsync(ulong id, CancellationToken cancellationToken);
        Task<T> Find(object[] keys, CancellationToken cancellationToken);
        Task<bool> Insert(T entity);
        Task<bool> InsertList(IEnumerable<T> entities);
        void SaveChanges();
        Task CreateDbAsync(CancellationToken cancellationToken);

    }
}