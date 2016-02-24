namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Client;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ClientController : Controller
    {
        private readonly IDbRepository<Client> clients;

        public ClientController(IDbRepository<Client> clients)
        {
            this.clients = clients;
        }

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult Clients_Read([DataSourceRequest] DataSourceRequest request)
        {
            var clients = this.clients.All();
            var result = clients.To<ClientViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Create([DataSourceRequest] DataSourceRequest request, ClientViewModel client)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Client { EIK = client.EIK, Name = client.Name, Address = client.Address };

                this.clients.Add(entity);
                this.clients.Save();
                client.Id = entity.Id;
            }

            return this.Json(
                new[]
                    {
                        client
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Update([DataSourceRequest] DataSourceRequest request, ClientViewModel client)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.clients.GetById(client.Id);
                
                entity.EIK = client.EIK;
                entity.Name = client.Name;
                entity.Address = client.Address;
                                 

                this.clients.Update(entity);
                this.clients.Save();
            }

            return this.Json(
                new[]
                    {
                        client
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Destroy([DataSourceRequest] DataSourceRequest request, ClientViewModel client)
        {
            var entity = new Client { Id = client.Id, EIK = client.EIK, Name = client.Name, Address = client.Address };

            this.clients.HardDelete(entity);
            this.clients.Save();

            return this.Json(
                new[]
                    {
                        client
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