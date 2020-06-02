using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Filter.Pipeline.Interfaces
{
    public interface IPipeline <TOutput>
    {
        Expression<Func<Tour, bool>> Execute();
    }
}
