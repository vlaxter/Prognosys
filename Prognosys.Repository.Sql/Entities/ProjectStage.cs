using System.Collections.Generic;

namespace Prognosys.Repository.Sql.Entities
{
    class ProjectStage : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
