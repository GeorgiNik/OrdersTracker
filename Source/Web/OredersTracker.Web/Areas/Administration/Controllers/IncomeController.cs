namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OredersTracker.Common;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Areas.Administration.ViewModels;
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
            var viewModel=new IncomeViewModel();
            return this.View(viewModel);
        }

        public ActionResult Search(string query)
        {
            //TODO: improve code quality and introduce service
            int month;
            
            if (!int.TryParse(query, out month))
            {
                return this.View(nameof(this.Details));
            }

            var orders = this.orderService.All().To<OrdersViewModel>().Where(x => x.CreatedOn.Month == month).ToList();
            var viewModel = new IncomeViewModel
                                {
                                    TotalForMonth = orders.Sum(x => x.OrderPrice),
                                    TotalForKornelia =
                                        orders.Where(x => x.Creator == "Корнелия").Sum(x => x.OrderPrice),
                                    TotalForMitko =
                                        orders.Where(x => x.Creator == "Митко").Sum(x => x.OrderPrice),
                                    TotalForNikola =
                                        orders.Where(x => x.Creator == "Никола").Sum(x => x.OrderPrice),
                                    TotalForStaiko =
                                        orders.Where(x => x.Creator == "Стайко").Sum(x => x.OrderPrice)
                                };



            return this.View(nameof(this.Details),viewModel);
        }
    }
}