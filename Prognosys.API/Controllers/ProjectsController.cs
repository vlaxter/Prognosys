using Prognosys.Shared.Interfaces.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prognosys.API.Controllers
{
    /// <summary>
    /// Manages projects requests
    /// </summary>
    [RoutePrefix("v1/Projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        /// <summary>
        /// Get a project by Id
        /// </summary>
        /// <param name="id">The id of the project</param>
        /// <returns>Returns a project model from an id</returns>
        [Route("Projects/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetProject(int id)
        {
            var project = _projectsService.GetProjet(id);
            var status = HttpStatusCode.OK;
            return Request.CreateResponse(status, project);
        }

        /// <summary>
        /// Get an It's working confirmation
        /// </summary>
        /// <remarks>
        /// The purpose is to test that All's working fine
        /// </remarks>
        /// <returns>
        /// Returns a confirmation that it's working
        /// </returns>
        [Route("Test")]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var status = HttpStatusCode.OK;
            return Request.CreateResponse(status,"It works!!");
        }
    }
}