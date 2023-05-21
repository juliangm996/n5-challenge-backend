using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using N5.Challenge.Api.Infraestructure.Entities;

namespace N5.Challenge.Api.Infraestructure
{
    public interface IDataContext : IDisposable
    {
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}