using System.Threading.Tasks;
using BusinessLayer.Helpers;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Extensions.Repository
{
    public static class RepositoryExtensions
    {
        public static async Task<Result> CheckExistence<TEntity>(
            this IReadonlyRepository<TEntity> repository, int id) where TEntity : BaseEntity
        {
            var isEntityExists = await repository.AnyAsync(entity => entity.Id == id);

            if (!isEntityExists)
            {
                return Result.Fail($"Entity {typeof(TEntity)} with id {id} wasn't found");
            }

            return Result.Ok();
        }
    }
}
