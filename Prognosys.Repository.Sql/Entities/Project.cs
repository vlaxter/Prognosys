using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prognosys.Repository.Sql.Entities
{
    class Project : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int StageId { get; set; }
        public virtual ProjectStage Stage { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Allocation> Allocations { get; set; }
    }    
}