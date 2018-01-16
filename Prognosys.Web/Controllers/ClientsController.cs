using Prognosys.ApiTools;
using Prognosys.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Prognosys.Web.Controllers
{
    public class ClientsController : Controller
    {
        string apiBaseUrl = "http://prognosys.api.local/v1/";

        public async Task<ActionResult> Index()
        {
            List<ClientModel> clientsList = new List<ClientModel>();

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                clientsList = apiClient.Get<List<ClientModel>>("clients");
            }
            
            return View(clientsList);
        }
    }
}
