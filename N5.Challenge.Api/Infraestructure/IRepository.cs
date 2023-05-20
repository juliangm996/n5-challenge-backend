using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace N5.Challenge.Api.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T FindById(params object[] keyValues);
        IQueryable<T> GetAllAsQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        IQueryable<T> GetAllAsQueryable();
        void Remove(T entity);
        void RemoveRange(ICollection<T> entities);
    }
}