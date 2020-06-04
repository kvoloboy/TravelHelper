using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Factories.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Create<TEntity>() where TEntity: BaseEntity;
    }
}
