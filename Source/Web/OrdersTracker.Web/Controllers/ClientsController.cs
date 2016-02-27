namespace OrdersTracker.Web.Controllers
{
    using System.Web.Mvc;

    using OrdersTracker.Data.Models;
    using OrdersTracker.Services.Data.Contracts;
    using OrdersTracker.Web.ViewModels.Client;

    [Authorize]
    public class ClientsController : BaseController
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
                var client = this.Mapper.Map<Client>(model);
                this.clientService.Add(client);
                this.TempData["Notification"] = "New client added!";
            }
            return this.RedirectToAction(nameof(this.Add));
        }
    }
}