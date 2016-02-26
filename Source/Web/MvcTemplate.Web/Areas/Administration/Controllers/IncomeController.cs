namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MvcTemplate.Common;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Web.Controllers;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Orders;

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
                return this.PartialView("_SearchPartial", result);
            }
            var orders =
                this.orderService.GetAll().To<OrdersViewModel>().Where(x => x.CreatedOn.Month == month).ToList();

            result = orders.Sum(x => x.OrderPrice);

            return this.PartialView("_SearchPartial", result);
        }
    }
}