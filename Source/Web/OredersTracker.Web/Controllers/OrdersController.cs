namespace OredersTracker.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using OredersTracker.Data.Common;
    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Infrastructure.Mapping;
    using OredersTracker.Web.ViewModels.Client;
    using OredersTracker.Web.ViewModels.Orders;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IClientService clientService;

        private readonly IDbRepository<Order> orders;

        private readonly IOrderService orderService;

        public OrdersController(IDbRepository<Order> orders, IOrderService orderService, IClientService clientService)
        {
            this.orders = orders;
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Create()
        {
            var clients = this.clientService.All();
            IEnumerable<SelectListItem> items =
                clients.To<ClientViewModel>().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            this.ViewBag.Clients = items;

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderCreateViewModel model)
        {
            var newOrder = this.Mapper.Map<Order>(model);
            newOrder.AuthorId = this.User.Identity.GetUserId();
            this.orderService.Add(newOrder);
            this.TempData["Notification"] = "New order created!";
            return this.RedirectToAction(nameof(this.Create));
        }

        public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.orders.All().To<OrdersViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Update([DataSourceRequest] DataSourceRequest request, OrdersViewModel order)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.orderService.GetById(order.Id);

                entity.Deadline = order.Deadline;
                entity.Description = order.Description;
                entity.OrderPrice = order.OrderPrice;
                entity.PaidInAdvance = order.PaidInAdvance;
                entity.BillInCash = order.BillInCash;
                entity.Receipt = order.Receipt;
                entity.PaidWithCard = order.PaidWithCard;
                entity.Econt = order.Econt;
                entity.PaidInCashWithoutReceipt = order.PaidInCashWithoutReceipt;
                entity.PaidBankTransaction = order.PaidBankTransaction;
                entity.LeftToBePaid = order.LeftToBePaid;
                entity.PaidAt = order.PaidAt;
                entity.DateOfComplition = order.DateOfComplition;
                entity.Bonuses = order.Bonuses;
                entity.IsComplited = order.IsComplited;

                this.orders.Update(entity);
                this.orders.Save();
            }

            return this.Json(
                new[]
                    {
                        order
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Destroy([DataSourceRequest] DataSourceRequest request, OrdersViewModel order)
        {
            this.orders.Delete(order.Id);
            this.orders.Save();

            return this.Json(
                new[]
                    {
                        order
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

        protected override void Dispose(bool disposing)
        {
            this.orders.Dispose();
            base.Dispose(disposing);
        }
    }
}