using BusinessLayer.Shared.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Shared.Sort.Builders.Interfaces
{
    public interface ISortOptionFactory
    {
        ISortOption<TEntity> Create<TEntity>(string sortTerm) where TEntity : BaseEntity;
    }
}
