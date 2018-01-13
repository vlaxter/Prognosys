using System;

namespace Prognosys.Repository.Sql.Entities
{
    class Allocation : EntityBase
    {
        public int Hours { get; set; }

        public DateTime Week { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
