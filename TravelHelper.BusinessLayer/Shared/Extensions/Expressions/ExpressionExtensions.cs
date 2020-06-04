using System;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Shared.Extensions.Expressions.Visitors;

namespace BusinessLayer.Shared.Extensions.Expressions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TEntity, bool>> And<TEntity>(
            this Expression<Func<TEntity, bool>> first,
            Expression<Func<TEntity, bool>> second)
        {
            return Compose(first, second, Expression.AndAlso);
        }

        public static Expression<Func<TEntity, bool>> Or<TEntity>(
            this Expression<Func<TEntity, bool>> first,
            Expression<Func<TEntity, bool>> second)
        {
            return Compose(first, second, Expression.OrElse);
        }

        private static Expression<Func<TEntity, bool>> Compose<TEntity>(
            Expression<Func<TEntity, bool>> first,
            Expression<Func<TEntity, bool>> second,
            Func<Expression, Expression, BinaryExpression> mergeFunc)
        {
            var secondBody = ParameterRebinder.Execute(first.Parameters.First(), second.Body);
            var resultExpression =
                Expression.Lambda<Func<TEntity, bool>>(mergeFunc(first.Body, secondBody), first.Parameters);

            return resultExpression;
        }
    }
}
