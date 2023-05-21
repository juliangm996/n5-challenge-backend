using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using N5.Challenge.Api.Infraestructure.Entities;

namespace N5.Challenge.Api.Infraestructure
{
    public class DataContext : DbContext, IDataContext
    {

        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.PermissionTypes)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.TipoPermiso);

            });

            modelBuilder.Entity<PermissionTypes>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

