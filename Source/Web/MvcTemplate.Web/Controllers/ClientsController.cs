namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Web.ViewModels.Client;

    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        private IOrderService orderService;

        public ClientsController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(ClientViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var client = new Client { EIK = model.EIK, Address = model.Address, Name = model.Name };
                this.clientService.Add(client);
                this.TempData["Notification"] = "New client added!";
            }
            return this.RedirectToAction(nameof(this.Add));
        }
    }
}