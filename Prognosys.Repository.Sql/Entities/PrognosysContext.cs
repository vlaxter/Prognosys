using System.Data.Entity;

namespace Prognosys.Repository.Sql.Entities
{
    public class PrognosysContext : DbContext
    {
        public PrognosysContext()
            : base("PrognosysContext")
        {
        }

        public DbSet<Project> Project { get; set; }
    }
}