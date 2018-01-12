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
        [HttpPut]
        public HttpResponseMessage Index()
        {
            var status = HttpStatusCode.OK;
            return Request.CreateResponse(status,"It works!!");
        }
    }
}