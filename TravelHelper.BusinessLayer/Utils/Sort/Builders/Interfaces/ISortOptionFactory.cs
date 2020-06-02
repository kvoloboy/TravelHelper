using BusinessLayer.Utils.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Sort.Builders.Interfaces
{
    public interface ISortOptionFactory
    {
        ISortOption<TEntity> Create<TEntity>(string sortTerm) where TEntity : BaseEntity;
    }
}
