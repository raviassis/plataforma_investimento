using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvestimentoApi.Shared
{
    public class QueryableExtensionWrapper: IQueryableExtensionWrapper
    {
        public T FirstOrDefault<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            return source.FirstOrDefault(predicate);
        }
    }

    public interface IQueryableExtensionWrapper
    {
        T FirstOrDefault<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate);
    }
}
