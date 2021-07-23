using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Paschoalotto.Devedor.Domain.Models.Database;
using Paschoalotto.Devedor.Infra.Mappings;

namespace Paschoalotto.Devedor.Infra.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext() { }
        public EntityContext(DbContextOptions<EntityContext> options)
             : base(options) { }

        public DbSet<Domain.Models.Database.Devedor> Devedor { get; set; }
        public DbSet<Parcela> Parcela { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DevedorMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("DateCreated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateCreated").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
