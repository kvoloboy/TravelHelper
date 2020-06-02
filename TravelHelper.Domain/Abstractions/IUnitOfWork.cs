using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace TravelHelper.Domain.Abstractions
{
    public interface IUnitOfWork
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        IReadonlyRepository<TEntity> GetReadonlyRepository<TEntity>() where TEntity : BaseEntity;
        Task CommitAsync();
    }
}
