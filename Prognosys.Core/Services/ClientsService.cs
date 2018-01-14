using AutoMapper;
using Prognosys.Shared.DTOs;
using Prognosys.Shared.Interfaces.Repositories;
using Prognosys.Shared.Interfaces.Services;
using Prognosys.Shared.MapperProfiles;
using Prognosys.Shared.Models;
using System;
using System.Linq;

namespace Prognosys.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IMapper _mapper;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
            _mapper = MapperInitializer.Initialize();
        }
    
        public ClientModel CreateClient(ClientModel client)
        {
            var newClient =_clientsRepository.CreateClient(_mapper.Map<ClientDto>(client));
            return _mapper.Map<ClientModel>(newClient);
        }

        public void DeleteClient(int id)
        {
            _clientsRepository.DeleteClient(id);
        }

        public ClientModel GetClient(int id)
        {
            var client =_clientsRepository.GetClient(id);
            return _mapper.Map<ClientModel>(client);
        }

        public IQueryable<ClientModel> GetClients()
        {
            var clients = _clientsRepository.GetClients();
            var clientsModelList = clients.Select(c => _mapper.Map<ClientModel>(c));
            return clientsModelList;
        }

        public void UpdateClient(int id, ClientModel clientModel)
        {
            _clientsRepository.UpdateClient(id, _mapper.Map<ClientDto>(clientModel));
        }
    }
}
