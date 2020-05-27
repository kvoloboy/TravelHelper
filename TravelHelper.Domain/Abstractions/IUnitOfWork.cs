using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace TravelHelper.Domain.Abstractions
{
    public interface IUnitOfWork
    {

        IAsyncRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        IAsyncReadonlyRepository<TEntity> GetReadonlyRepository<TEntity>() where TEntity : BaseEntity;
        Task CommitAsync();
    }
}
