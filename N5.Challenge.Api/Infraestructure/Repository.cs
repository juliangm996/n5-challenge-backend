using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using N5.Challenge.Api.Infraestructure.Entities;

namespace N5.Challenge.Api.Infraestructure
{
    public class Repository : IRepository
    {
        private readonly IDataContext _context;

        public Repository(IDataContext context)
        {
            _context = context;
        }

        public Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
          IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
          where T : class
        {
            var query = expression != null ? _context.Set<T>().Where(expression) : _context.Set<T>();
            return orderBy != null
                ? orderBy(query).ToListAsync(cancellationToken)
                : query.ToListAsync(cancellationToken);
        }

        public T Add<T>(T entity) where T : IEntity
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public void Update<T>(T entity) where T : IEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


    }
}
