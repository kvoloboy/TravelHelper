using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace TravelHelper.Domain.Abstractions
{
    public interface IRepository<TEntity> : IReadonlyRepository<TEntity>
        where TEntity: BaseEntity
    {
        Task<int> AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(int id);
    }
}
