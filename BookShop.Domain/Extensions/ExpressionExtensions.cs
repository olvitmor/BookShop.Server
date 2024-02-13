using System.Linq.Expressions;

namespace BookShop.Domain.Extensions;

#nullable disable
public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> AddAndAlsoConditionWhenTrue<T>(
        this Expression<Func<T, bool>> leftOperand,
        bool needProcess,
        Expression<Func<T, bool>> rightOperand)
    {
        return !needProcess ? leftOperand : leftOperand.AddAndAlsoCondition(rightOperand);
    }

    public static Expression<Func<T, bool>> AddAndAlsoCondition<T>(
        this Expression<Func<T, bool>> leftOperand,
        Expression<Func<T, bool>> rightOperand)
    {
        var parameter = leftOperand.Parameters[0];
        return Expression.Lambda<Func<T, bool>>(
            body: (Expression)Expression.AndAlso(
                left: GetModifiedOperand<T>(leftOperand, (Expression)parameter),
                right: GetModifiedOperand<T>(rightOperand, (Expression)parameter)),
            parameter);
    }

    private static Expression GetModifiedOperand<T>(
        Expression<Func<T, bool>> expression,
        Expression parameter)
    {
        return new LocalExpressionVisitor(
            (Expression)expression.Parameters[0],
            parameter).Visit(expression.Body);
    }

    private class LocalExpressionVisitor(Expression oldValue, Expression newValue) : ExpressionVisitor
    {
        private readonly Expression _oldValue = oldValue;
        private readonly Expression _newValue = newValue;

        public override Expression Visit(Expression node)
        {
            return node != this._oldValue ? base.Visit(node) : this._newValue;
        }
    }
}