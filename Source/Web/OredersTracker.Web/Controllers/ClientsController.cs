namespace OredersTracker.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Infrastructure.Mapping;
    using OredersTracker.Web.ViewModels.Client;

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

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult Clients_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.clientService.All().To<ClientViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Create([DataSourceRequest] DataSourceRequest request, ClientViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var client = this.Mapper.Map<Client>(model);
                this.clientService.Add(client);
                model.Id = client.Id;
            }

            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Update([DataSourceRequest] DataSourceRequest request, ClientViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var client = this.Mapper.Map<Client>(model);
                this.clientService.Update(client);
            }

            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Destroy([DataSourceRequest] DataSourceRequest request, ClientViewModel model)
        {
            var client = this.Mapper.Map<Client>(model);
            this.clientService.Delete(client);

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