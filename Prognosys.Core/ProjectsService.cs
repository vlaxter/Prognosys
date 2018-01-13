using Prognosys.Shared.DTOs;
using Prognosys.Shared.Interfaces.Repositories;
using Prognosys.Shared.Interfaces.Services;
using Prognosys.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Core
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public ProjectModel GetProjet(int id)
        {
            var project = _projectsRepository.GetProject(id);
            return new ProjectModel { ID = project.ID, Name = project.Name };
        }
    }
}