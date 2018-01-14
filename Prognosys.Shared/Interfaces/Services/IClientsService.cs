using Prognosys.Shared.Models;
using System.Linq;

namespace Prognosys.Shared.Interfaces.Services
{
    public interface IClientsService
    {
        IQueryable<ClientModel> GetClients();

        ClientModel GetClient(int id);

        void UpdateClient(int id, ClientModel clientModel);

        ClientModel CreateClient(ClientModel clientModel);

        void DeleteClient(int id);
    }
}
