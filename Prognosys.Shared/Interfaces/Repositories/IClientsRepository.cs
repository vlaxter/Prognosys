using Prognosys.Shared.DTOs;
using System.Linq;

namespace Prognosys.Shared.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        IQueryable<ClientDto> GetClients();

        ClientDto GetClient(int id);

        void UpdateClient(int id, ClientDto clientDto);

        ClientDto CreateClient(ClientDto clientDto);

        void DeleteClient(int id);
    }
}
