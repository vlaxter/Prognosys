using Prognosys.Shared.DTOs;
using Prognosys.Shared.Interfaces.Repositories;
using Prognosys.Shared.Interfaces.Services;
using Prognosys.Shared.Models;
using System;
using System.Linq;

namespace Prognosys.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
    
        public ClientModel CreateClient(ClientModel client)
        {
            var newClient =_clientsRepository.CreateClient(new ClientDto { Name = client.Name });
            return new ClientModel { Id = newClient.Id, Name = newClient.Name };
        }

        public void DeleteClient(int id)
        {
            _clientsRepository.DeleteClient(id);
        }

        public ClientModel GetClient(int id)
        {
            var client =_clientsRepository.GetClient(id);
            return new ClientModel { Id = client.Id, Name = client.Name };
        }

        public IQueryable<ClientModel> GetClients()
        {
            return _clientsRepository.GetClients().Select(c => new ClientModel { Id = c.Id, Name = c.Name });
        }

        public void UpdateClient(int id, ClientModel clientModel)
        {
            _clientsRepository.UpdateClient(id, new ClientDto { Id = clientModel.Id, Name = clientModel.Name });
        }
    }
}
