using System.Linq.Expressions;
using N5.Challenge.Api.Entities;

namespace N5.Challenge.Api.Repositories
{
    public interface IRepository
    {
        Task<T?> GetById<T>(int id) where T : IEntity;

       T Add<T>(T entity) where T : IEntity;
        Task<List<T>> FindAllAsync<T>(CancellationToken cancellationToken = default) where T : class;
        void Update<T>(T entity) where T : IEntity;
    }
}