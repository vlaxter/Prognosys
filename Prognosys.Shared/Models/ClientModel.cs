using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Shared.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectModel> Projects { get; set; }
    }
}
