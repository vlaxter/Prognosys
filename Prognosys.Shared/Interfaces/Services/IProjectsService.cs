using Prognosys.Shared.DTOs;
using Prognosys.Shared.Models;
using System.Collections.Generic;

namespace Prognosys.Shared.Interfaces.Services
{
    public interface IProjectsService
    {
        ProjectModel GetProjet(int id);
    }
}
