using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.DbHelper
{
    public class LinqHelper
    {
        public static IQueryable<T> CreateSortQuery<T>(IQueryable<T> query, string sortType, string field)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), field);

            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(field);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;

            string sortWith;
            if (sortType == "Asc")
                sortWith = "OrderBy";
            else
                sortWith = "OrderByDescending";

            Expression exp = Expression.Call(typeof(Queryable), sortWith, types, query.Expression, Expression.Lambda(Expression.Property(param, field), param));
            return query.AsQueryable().Provider.CreateQuery<T>(exp);
        }
    }
}
