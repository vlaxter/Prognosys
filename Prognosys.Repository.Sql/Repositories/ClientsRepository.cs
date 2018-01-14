using Prognosys.Repository.Sql.Entities;
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

        public ClientsRepository()
        {
            _context = new PrognosysContext();
        }

        public ClientDto CreateClient(ClientDto clientDto)
        {
            var client = new Client { Name = clientDto.Name };
            var newClient = _context.Clients.Add(client);
            _context.SaveChanges();
            return new ClientDto { Id = client.Id, Name = client.Name };
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
            return new ClientDto { Id = client.Id, Name = client.Name };
        }

        public IQueryable<ClientDto> GetClients()
        {
            return _context.Clients.Select(c => new ClientDto { Id = c.Id, Name = c.Name });
        }

        public void UpdateClient(int id, ClientDto clientDto)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new NotFoundInRepositoryException();
            }

            // Replace with mapping tool
            client.Name = clientDto.Name;

            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
