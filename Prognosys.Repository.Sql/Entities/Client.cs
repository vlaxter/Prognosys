using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prognosys.Repository.Sql.Entities
{
    class Client : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
