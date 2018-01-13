using Prognosys.Repository.Sql.Entities;
using Prognosys.Shared.DTOs;
using Prognosys.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Repository.Sql.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly PrognosysContext _context;

        public ProjectsRepository()
        {
            _context = new PrognosysContext();
        }

        public ProjectDto GetProject(int id)
        {
            var project = _context.Projects.Find(id);
            return new ProjectDto { ID = project.Id, Name = project.Name };
        }
    }
}