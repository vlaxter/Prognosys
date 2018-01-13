using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prognosys.Repository.Sql.Entities
{
    class Resource : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public int Capacity { get; set; }

        public int RoldeId { get; set; }
        public virtual ResourceRole Role { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
