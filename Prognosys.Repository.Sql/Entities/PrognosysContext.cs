using System;
using System.Data.Entity;
using System.Linq;

namespace Prognosys.Repository.Sql.Entities
{
    class PrognosysContext : DbContext
    {
        public PrognosysContext()
            : base("PrognosysContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ProjectStage> ProjectStages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceRole> ResourceRoles { get; set; }

        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<EntityBase>();

            if (changeSet != null)
            {
                var now = DateTime.UtcNow;

                foreach (var entry in changeSet.Where(c => c.State == EntityState.Modified || c.State == EntityState.Added))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreationDate = now;
                    }
                    entry.Entity.LastModified = now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany<Resource>(project => project.Resources)
                .WithMany(resource => resource.Projects)
                .Map(cs =>
                {
                    cs.MapLeftKey("ResourceId");
                    cs.MapRightKey("ProjectId");
                    cs.ToTable("ProjectResources");
                });
        }
    }
}