using Prognosys.Shared.DTOs;
using System.Collections.Generic;

namespace Prognosys.Shared.Interfaces.Services
{
    public interface IProjectsService
    {
        List<ProjectDto> GetProjets();
    }
}
