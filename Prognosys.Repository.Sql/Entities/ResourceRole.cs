using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Repository.Sql.Entities
{
    class ResourceRole : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
