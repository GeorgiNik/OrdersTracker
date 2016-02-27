namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OredersTracker.Common;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Controllers;
    using OredersTracker.Web.Infrastructure.Mapping;
    using OredersTracker.Web.ViewModels.Orders;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class IncomeController : BaseController
    {
        private readonly IClientService clientService;

        private readonly IOrderService orderService;

        public IncomeController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult Search(string query)
        {
            int month;
            var result = 0M;
            if (!int.TryParse(query, out month))
            {
                return this.View(nameof(this.Details),result);
            }
            var orders =
                this.orderService.GetAll().To<OrdersViewModel>().Where(x => x.CreatedOn.Month == month).ToList();

            result = orders.Sum(x => x.OrderPrice);

            return this.View(nameof(this.Details),result);
        }
    }
}