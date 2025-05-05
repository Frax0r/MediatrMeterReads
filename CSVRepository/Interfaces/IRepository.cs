using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIDAsync(ulong id, CancellationToken cancellationToken);
        Task<T> FindAsync(object[] keys, CancellationToken cancellationToken);
        Task InsertAsync(T entity);
    }
}