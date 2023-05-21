using System.Linq.Expressions;
using N5.Challenge.Api.Infraestructure.Entities;

namespace N5.Challenge.Api.Infraestructure
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : IEntity;
        Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default) where T : class;
        void Update<T>(T entity) where T : IEntity;
    }
}