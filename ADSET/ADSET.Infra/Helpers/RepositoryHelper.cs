using System.Linq.Expressions;

namespace ADSET.Infra.Helpers
{
    public static class RepositoryHelper
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, bool apply, Expression<Func<T, bool>> predicate)
            => apply ? query.Where(predicate) : query;

        public static IQueryable<T> OrderByAsc<T, TResult>(this IQueryable<T> query, bool apply, Expression<Func<T, TResult>> predicate)
            => apply ? query.OrderBy(predicate) : query;

        public static IQueryable<T> OrderByDesc<T, TResult>(this IQueryable<T> query, bool apply, Expression<Func<T, TResult>> predicate)
            => apply ? query.OrderByDescending(predicate) : query;
    }
}
