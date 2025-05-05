using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
