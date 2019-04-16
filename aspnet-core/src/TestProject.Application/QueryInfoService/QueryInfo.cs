using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TestProject.QueryInfoService
{
    public class QueryInfo
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string SearchText { get; set; }
        public List<string> SearchProperties { get; set; }
        public List<Sort> Sorters { get; set; }
        public Filter Filter { get; set; }

        public BinaryExpression GetBinaryExpression(ParameterExpression parameterEx, string operatorValue,
            string propertyName, string searchValue)
        {
            Expression propertyEx = parameterEx;
            propertyEx = Expression.Property(propertyEx, propertyName);

            var type = propertyEx.Type;
            var convertedTypeValue = Convert.ChangeType(searchValue, type);
            var constantEx = Expression.Constant(convertedTypeValue);

            BinaryExpression binaryEx;
            switch (convertedTypeValue)
            {
                case string _:
                    binaryEx = GetBinaryExpressionForString(operatorValue, propertyEx, constantEx);
                    break;
                case int _:
                    binaryEx = GetBinaryExpressionForInt(operatorValue, propertyEx, constantEx);
                    break;
                default:
                    throw new ArgumentException();
            }

            return binaryEx;
        }
        
        public Expression<Func<TEntity, bool>> GetWhere<TEntity>(Expression binary, ParameterExpression parameterEx)
        {
            return Expression.Lambda<Func<TEntity, bool>>(binary, parameterEx);
        }
        
        private static BinaryExpression GetBinaryExpressionForString(string operatorValue, Expression propertyEx,
            ConstantExpression constantEx)
        {
            BinaryExpression binEx;
            var trueExpression = Expression.Constant(true, typeof(bool));
            var ignore = Expression.Constant(StringComparison.OrdinalIgnoreCase);
            switch (operatorValue)
            {
                case "eq":
                    return Expression.Equal(propertyEx, constantEx);
                case "ct":
                    MethodInfo containsMethodInfo = typeof(string).GetMethod("Contains", new[] {typeof(string), typeof(StringComparison)});
                    var contains = Expression.Call(propertyEx, containsMethodInfo, constantEx, ignore);
                    binEx = Expression.Equal(contains, trueExpression);
                    break;
                case "stw":
                    MethodInfo startsWithMethodInfo = typeof(string).GetMethod("StartsWith", new[] { typeof(string), typeof(StringComparison) });
                    var startsWith = Expression.Call(propertyEx, startsWithMethodInfo, constantEx, ignore);
                    binEx = Expression.Equal(startsWith, trueExpression);
                    break;
                case "enw":
                    MethodInfo endsWithMethodInfo = typeof(string).GetMethod("EndsWith", new[] { typeof(string), typeof(StringComparison) });
                    var endsWith = Expression.Call(propertyEx, endsWithMethodInfo, constantEx, ignore);
                    binEx = Expression.Equal(endsWith, trueExpression);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return binEx;
        }
        
        private static BinaryExpression GetBinaryExpressionForInt(string operatorValue, Expression propertyEx,
            ConstantExpression constantEx)
        {
            switch (operatorValue)
            {
                case "gt":
                    return Expression.GreaterThan(propertyEx, constantEx);
                case "lt":
                    return Expression.LessThan(propertyEx, constantEx);
                case "eq":
                    return Expression.Equal(propertyEx, constantEx);
                case "loe":
                    return Expression.LessThanOrEqual(propertyEx, constantEx);
                case "goe":
                    return Expression.GreaterThanOrEqual(propertyEx, constantEx);
                default:
                    throw new InvalidOperationException();
            }
        }

        public Expression<Func<TEntity, object>> GetOrderByExpression<TEntity>(string propertyName)
        {
            ParameterExpression parameterEx = Expression.Parameter(typeof(TEntity), "x");
            var property = propertyName;
            var propertyEx = Expression.Property(parameterEx, property);
            var convertEx = Expression.Convert(propertyEx, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(convertEx, parameterEx);
        }

        public Expression GetFilteredList<TEntity>(ParameterExpression parameter, List<Rule> rules, string condition)
        {
            Expression result;

            if (condition == "and")
            {
                Expression<Func<Models.Device, bool>> trueExp = x => true;
                result = trueExp.Body;
            }
            else
            {
                Expression<Func<Models.Device, bool>> falseExp = x => false;
                result = falseExp.Body;
            }

            foreach (var rule in rules)
            {
                Expression propertyEx = Expression.Property(parameter, rule.Property);
                var type = propertyEx.Type;
                var value = rule.Value;
                var convertedTypeValue = Convert.ChangeType(value, type);
                var constantEx = Expression.Constant(convertedTypeValue);

                BinaryExpression binaryEx;
                switch (convertedTypeValue)
                {
                    case string _:
                        binaryEx = GetBinaryExpressionForString(rule.Operator, propertyEx, constantEx);
                        break;
                    case int _:
                        binaryEx = GetBinaryExpressionForInt(rule.Operator, propertyEx, constantEx);
                        break;
                    default:
                        throw new ArgumentException();
                }

                switch (condition)
                {
                    case "and":
                        result = Expression.AndAlso(result, binaryEx);
                        break;
                    case "or":
                        result = Expression.OrElse(result, binaryEx);
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                if (rule.Condition == null)
                {
                    continue;

                }

                switch (condition)
                {
                    case "and":
                        result =  Expression.AndAlso(result, GetFilteredList<TEntity>(parameter, rule.Rules, rule.Condition));
                        break;
                    case "or":
                        result = Expression.OrElse(result, GetFilteredList<TEntity>(parameter, rule.Rules, rule.Condition));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return result;
        }
    }
}
