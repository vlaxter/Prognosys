using Prognosys.ApiTools;
using Prognosys.Shared.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Prognosys.Web.Controllers
{
    public class BasicClientsController : Controller
    {
        string apiBaseUrl = Settings.PrognosysApiBaseUri;

        public ActionResult Index()
        {
            List<ClientModel> clientsList;

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                clientsList = apiClient.Get<List<ClientModel>>("clients");
            }
            
            return View(clientsList);
        }
        
        // GET: Countries1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientModel client;

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                client = apiClient.Get<ClientModel>(string.Format("clients/{0}", id));
            }

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] ClientModel client)
        {            
            if (ModelState.IsValid)
            {
                using (var apiClient = new ApiClient(apiBaseUrl))
                {
                    apiClient.Post<ClientModel>("clients",client);
                }

                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Countries1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientModel client;

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                client = apiClient.Get<ClientModel>(string.Format("clients/{0}",id));
            }

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ClientModel client)
        {
            if (ModelState.IsValid)
            {
                using (var apiClient = new ApiClient(apiBaseUrl))
                {
                    apiClient.Put(string.Format("clients/{0}", client.Id), client);
                }

                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Countries1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientModel client;

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                client = apiClient.Get<ClientModel>(string.Format("clients/{0}", id));
            }

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Countries1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                apiClient.Delete(string.Format("clients/{0}", id));
            }
            return RedirectToAction("Index");
        }
    }
}
