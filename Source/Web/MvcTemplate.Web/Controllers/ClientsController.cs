using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web.Controllers
{
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.ViewModels.Client;

    [Authorize]
    public class ClientsController : Controller
    {
        private IOrderService orderService;
        private IClientService clientService;

        public ClientsController( IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client() { EIK = model.EIK, Address = model.Address, Name = model.Name };
                this.clientService.Add(client);
                this.TempData["Notification"] = "New order created!";
            }
            return this.RedirectToAction(nameof(this.Add));
        }
    }
}