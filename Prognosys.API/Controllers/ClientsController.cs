using Prognosys.Shared.Exceptions;
using Prognosys.Shared.Interfaces.Services;
using Prognosys.Shared.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Prognosys.API.Controllers
{
    /// <summary>
    /// Controller for Clientes
    /// </summary>
    [RoutePrefix("v1/Clients")]
    public class ClientsController : ApiController
    {
        private readonly IClientsService _clientsService;

        /// <summary>
        /// Constructor to inject the clients service dependency
        /// </summary>
        /// <param name="clientsService">Clients service instance</param>
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        /// <summary>
        /// Get the list of clients
        /// </summary>
        /// <returns>Returns the lis of clients</returns>
        [HttpGet]
        [Route("")]
        public IQueryable<ClientModel> GetClients()
        {
            return _clientsService.GetClients();
        }

        /// <summary>
        /// Get clients by Id
        /// </summary>
        /// <param name="id">Id of the client</param>
        /// <returns>Returns a client</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(ClientModel))]
        public IHttpActionResult GetClient(int id)
        {
            try
            {
                return Ok(_clientsService.GetClient(id));
            }
            catch (NotFoundInRepositoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Partialy updates a client
        /// </summary>
        /// <param name="id">Id of the clientes</param>
        /// <param name="clientModel">Modified client</param>
        /// <returns>Http result</returns>
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, ClientModel clientModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _clientsService.UpdateClient(id, clientModel);
            }
            catch (NotFoundInRepositoryException ex)
            {
                BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Creates a new client
        /// </summary>
        /// <param name="clientModel">New client object</param>
        /// <returns>Http result</returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(ClientModel))]
        public IHttpActionResult PostClient(ClientModel clientModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_clientsService.CreateClient(clientModel));
        }

        /// <summary>
        /// Delets a client
        /// </summary>
        /// <param name="id">Id of the client to be deleted</param>
        /// <returns>Http response</returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteClient(int id)
        {
            try
            {
                _clientsService.DeleteClient(id);
            }
            catch (NotFoundInRepositoryException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}