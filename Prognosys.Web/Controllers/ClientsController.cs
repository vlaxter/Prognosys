using AutoMapper;
using Prognosys.ApiTools;
using Prognosys.Shared.Models;
using Prognosys.Web.Mapper;
using Prognosys.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prognosys.Web.Controllers
{
    public class ClientsController : Controller
    {
        string apiBaseUrl = Settings.PrognosysApiBaseUri;
        private readonly IMapper _mapper;

        public ClientsController()
        {
            _mapper = ViewModelMapper.Initialize();
        }

        // GET: Clients
        public ActionResult Index()
        {
            List<ClientViewModel> clients;

            using (var apiClient = new ApiClient(apiBaseUrl))
            {
                var clientsList = apiClient.Get<List<ClientModel>>("clients");
                clients = _mapper.Map<List<ClientViewModel>>(clientsList);
            }

            return View(clients);
        }

        public ActionResult ShowModalContent(int id)
        {
            return PartialView("Modals/_ModalContent");
        }

        [HttpPost]
        public ActionResult ModalContent()
        {
            return RedirectToAction("Index");
        }
    }
}