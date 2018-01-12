using Prognosys.Repository.Sql.Entities;
using Prognosys.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Repository.Sql.Repositories
{
    public class ProjectsRepository
    {
        private PrognosysContext db;

        public ProjectsRepository()
        {
            db = new PrognosysContext();
        }

        public ProjectDto GetProject(int id)
        {
            var project = db.Projects.Find(id);
            return new ProjectDto { ID = project.Id, Name = project.Name };
        }
    }
}
