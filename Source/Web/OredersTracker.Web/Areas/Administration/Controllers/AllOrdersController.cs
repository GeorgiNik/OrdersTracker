﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Controllers;
    using OredersTracker.Web.Infrastructure.Mapping;
    using OredersTracker.Web.ViewModels.Client;
    using OredersTracker.Web.ViewModels.Orders;

    public class AllOrdersController : BaseController
    {
        // GET: Administration/AllOrders
        

        private readonly IClientService clientService;

        private readonly IOrderService orderService;

        public AllOrdersController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }

        public ActionResult Details()
        {
            return View();
        }

        
       
        public ActionResult AllOrders_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.orderService.All().To<OrdersViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AllOrders_Update([DataSourceRequest] DataSourceRequest request, OrdersViewModel model)
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
        public ActionResult AllOrders_Destroy([DataSourceRequest] DataSourceRequest request, OrdersViewModel model)
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