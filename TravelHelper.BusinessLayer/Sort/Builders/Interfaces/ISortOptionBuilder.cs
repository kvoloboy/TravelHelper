using BusinessLayer.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Sort.Builders.Interfaces
{
    public interface ISortOptionBuilder
    {
        ISortOption<TEntity> Create<TEntity>(string sortTerm) where TEntity : BaseEntity;
    }
}
