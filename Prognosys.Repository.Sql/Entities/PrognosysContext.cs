using System.Data.Entity;

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
        public DbSet<ProjectStage> ProjectStages  { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceRole> ResourceRoles { get; set; }

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