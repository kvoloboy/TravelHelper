using System;
using System.Linq.Expressions;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Filter.Pipeline.Interfaces
{
    public interface IPipeline <TOutput>
    {
        Expression<Func<Tour, bool>> Execute();
    }
}
