using Prognosys.Shared.Models;

namespace Prognosys.Shared.Interfaces.Services
{
    public interface IProjectsService
    {
        ProjectModel GetProjet(int id);
    }
}
