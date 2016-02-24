namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;

    using MvcTemplate.Common;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IOrderService orders;

        private readonly IClientService clients;

        private readonly IUserService users;
       
        public HomeController(IClientService clients, IOrderService orders, IUserService users)
        {
            this.orders = orders;
            this.clients = clients;
            this.users = users;
        }

        //[OutputCache(Duration = GlobalConstants.HomePageCacheDuration)]
        public ActionResult Index()
        {
            var totalUsers = this.users.GetUsersCount();
            var totalOrders = this.orders.GetAll().Count();
            var totalClients = this.clients.GetAll().Count();
            var viewModel = new HomeViewModel()
                                {
                                    ClientsCount = totalClients,
                                    OrdersCount = totalOrders,
                                    UsersCount = totalUsers
                                };
            return this.View(viewModel);
        }
        
    }
}