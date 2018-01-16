using AutoMapper;
using AutoMapper.QueryableExtensions;
using Prognosys.Repository.Sql.Entities;
using Prognosys.Repository.Sql.Mapper;
using Prognosys.Shared.DTOs;
using Prognosys.Shared.Exceptions;
using Prognosys.Shared.Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Prognosys.Repository.Sql.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly PrognosysContext _context;
        private readonly IMapper _mapper;

        public ClientsRepository()
        {
            _context = new PrognosysContext();
            _mapper = RepositoryMapper.Initialize();
        }

        public ClientDto CreateClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client = _context.Clients.Add(client);
            _context.SaveChanges();

            return _mapper.Map<ClientDto>(client);
        }

        public void DeleteClient(int id)
        {
            Client client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new NotFoundInRepositoryException();
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public ClientDto GetClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new NotFoundInRepositoryException();
            }

            return _mapper.Map<ClientDto>(client);
        }

        public IQueryable<ClientDto> GetClients()
        {
            var mapperConfig = _mapper.ConfigurationProvider;
            var clients = _context.Clients.ProjectTo<ClientDto>(mapperConfig);
            return clients;
        }

        public void UpdateClient(int id, ClientDto clientDto)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new NotFoundInRepositoryException();
            }

            _mapper.Map(clientDto, client);

            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
