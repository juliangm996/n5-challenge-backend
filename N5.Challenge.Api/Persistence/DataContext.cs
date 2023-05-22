using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using N5.Challenge.Api.Entities;
using Nest;

namespace N5.Challenge.Api.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        public ElasticClient ElasticClient { get;}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
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

            //Seed Data
            modelBuilder.Entity<PermissionTypes>().HasData(
                new PermissionTypes { Id = 1, Descripcion = "Type 1" },
                new PermissionTypes { Id = 2, Descripcion = "Type 2" }
                );


        }
    }
}

