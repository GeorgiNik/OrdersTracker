﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MvcTemplate.Data.Models;

namespace MvcTemplate.Web.Controllers
{
    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Client;
    using MvcTemplate.Web.ViewModels.Orders;
    [Authorize]
    public class OrdersController : Controller
    {
        private IDbRepository<Order> orders;

        private IOrderService orderService;
        private IClientService clientService;

        public OrdersController(IDbRepository<Order> orders, IOrderService orderService, IClientService clientService)
        {
            this.orders = orders;
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var clients = this.clientService.GetAll();
            IEnumerable<SelectListItem> items = clients.To<ClientViewModel>().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            ViewBag.Clients = items;


            return this.View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderCreateViewModel model)
        {
            var order = new Order()
                            {
                                ClientId = model.ClientId,
                                AuthorId = this.User.Identity.GetUserId(),
                                Deadline = model.Deadline,
                                PaidAt = model.PaidAt,
                                BillInCash = model.BillInCash,
                                Bonuses = model.Bonuses,
                                Description = model.Description,
                                Econt = model.Econt,
                                LeftToBePaid = model.LeftToBePaid,
                                Receipt = model.Receipt,
                                PaidWithCard = model.PaidWithCard,
                                PaidBankTransaction = model.PaidBankTransaction,
                                PaidInCashWithoutReceipt = model.PaidInCashWithoutReceipt,
                                PaidInAdvance = model.PaidInAdvance,
                                OrderPrice = model.OrderPrice
                            };
            this.orderService.Add(order);
            this.TempData["Notification"] = "New order created!";
            return this.RedirectToAction(nameof(this.Create));
        }
        public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
        {

            DataSourceResult result = this.orders.All().To<OrdersViewModel>().ToDataSourceResult(request);

            return Json(result);
        }

       
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Update([DataSourceRequest]DataSourceRequest request, OrdersViewModel order)
        {
            if (ModelState.IsValid)
            {
                var entity = this.orderService.GetById(order.Id);

                entity.Id = order.Id;
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

            return Json(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Orders_Destroy([DataSourceRequest]DataSourceRequest request, OrdersViewModel order)
        {


            this.orders.Delete(order.Id);
            this.orders.Save();
            

            return Json(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.orders.Dispose();
            base.Dispose(disposing);
        }
    }
}
