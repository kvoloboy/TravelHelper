using System.Threading.Tasks;
using BusinessLayer.Helpers;

namespace BusinessLayer.Validators.Interfaces
{
    public interface IValidator<in TContext>
    {
        Task<Result> Validate(TContext context);
    }
}
