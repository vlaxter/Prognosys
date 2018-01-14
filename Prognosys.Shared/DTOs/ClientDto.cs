using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Shared.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectDto> Projects { get; set; }
    }
}
