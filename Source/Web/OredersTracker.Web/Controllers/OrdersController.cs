namespace OredersTracker.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Infrastructure.Mapping;
    using OredersTracker.Web.ViewModels.Client;
    using OredersTracker.Web.ViewModels.Orders;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IClientService clientService;

        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Create()
        {
            var clients = this.clientService.All().OrderBy(x=>x.Name);
            IEnumerable<SelectListItem> items =
                clients.To<ClientViewModel>().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            this.ViewBag.Clients = items;

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var newOrder = this.Mapper.Map<Order>(model);
                newOrder.AuthorId = this.User.Identity.GetUserId();
                this.orderService.Add(newOrder);

                this.TempData["Notification"] = "New order created!";
            }
            return this.RedirectToAction(nameof(this.Create));
        }

        public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.orderService.GetCurrentUserOrders(this.User.Identity.GetUserId()).To<OrdersViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Update([DataSourceRequest] DataSourceRequest request, OrdersViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var order = this.Mapper.Map<Order>(model);
                this.orderService.Update(order);
            }

            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Destroy([DataSourceRequest] DataSourceRequest request, OrdersViewModel model)
        {
            var order = this.Mapper.Map<Order>(model);
            this.orderService.Delete(order);

            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}