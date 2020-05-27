using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace TravelHelper.Domain.Abstractions
{
    public interface IAsyncRepository<TEntity> : IAsyncReadonlyRepository<TEntity>
        where TEntity: BaseEntity
    {
        Task<int> AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(int id);
    }
}
