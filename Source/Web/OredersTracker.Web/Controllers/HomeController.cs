namespace OredersTracker.Web.Controllers
{
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;

    using OredersTracker.Common;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IClientService clients;

        private readonly IOrderService orders;

        private readonly IUserService users;

        public HomeController(IClientService clients, IOrderService orders, IUserService users)
        {
            this.orders = orders;
            this.clients = clients;
            this.users = users;
        }

        public ActionResult Index()
        {
            var totalUsers = this.Cache.Get(
                "users",
                () => this.users.GetUsersCount(),
                GlobalConstants.HomePageCacheDuration);
            var totalOrders = this.Cache.Get(
                "orders",
                () => this.orders.GetAll().Count(),
                GlobalConstants.HomePageCacheDuration);
            var totalClients = this.Cache.Get(
                "clients",
                () => this.clients.All().Count(),
                GlobalConstants.HomePageCacheDuration);
            var viewModel = new HomeViewModel
                                {
                                    ClientsCount = totalClients,
                                    OrdersCount = totalOrders,
                                    UsersCount = totalUsers
                                };
            return this.View(viewModel);
        }
    }
}