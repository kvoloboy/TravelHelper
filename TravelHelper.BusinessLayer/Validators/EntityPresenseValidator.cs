using System;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using BusinessLayer.Validators.Interfaces;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Validators
{
    public class EntityPresenceValidator<TEntity> : IValidator<int> where TEntity : BaseEntity
    {
        private readonly IAsyncReadonlyRepository<TEntity> _readonlyRepository;

        public EntityPresenceValidator(IUnitOfWork unitOfWork)
        {
            _readonlyRepository = unitOfWork.GetReadonlyRepository<TEntity>();
        }

        public async Task<Result> Validate(int id)
        {
            var isEntityExists = await _readonlyRepository.AnyAsync(entity => entity.Id == id);

            if (!isEntityExists)
            {
                return Result.Fail($"Entity {typeof(TEntity)} with id {id} wasn't found");
            }

            return Result.Ok();
        }
    }
}
