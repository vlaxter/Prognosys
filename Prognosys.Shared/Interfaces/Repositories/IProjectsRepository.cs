using Prognosys.Shared.DTOs;

namespace Prognosys.Shared.Interfaces.Repositories
{
    public interface IProjectsRepository
    {
        ProjectDto GetProject(int id);
    }
}
