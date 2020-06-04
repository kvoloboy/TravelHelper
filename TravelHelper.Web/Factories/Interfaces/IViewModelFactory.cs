using System.Threading.Tasks;

namespace TravelHelper.Web.Factories.Interfaces
{
    public interface IViewModelFactory<in TInput, TOutput>
    {
        Task<TOutput> CreateAsync(TInput input);
    }
}
