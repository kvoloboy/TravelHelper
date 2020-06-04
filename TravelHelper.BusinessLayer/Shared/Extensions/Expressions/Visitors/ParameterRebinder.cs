using System.Linq.Expressions;

namespace BusinessLayer.Shared.Extensions.Expressions.Visitors
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly ParameterExpression _parameterToReplace;

        private ParameterRebinder(ParameterExpression parameterToReplace)
        {
            _parameterToReplace = parameterToReplace;
        }

        public static Expression Execute(
            ParameterExpression parameterToReplace,
            Expression target)
        {

            var expression = new ParameterRebinder(parameterToReplace).Visit(target);

            return expression;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_parameterToReplace != null)
            {
                node = _parameterToReplace;
            }

            return base.VisitParameter(node);
        }
    }
}
