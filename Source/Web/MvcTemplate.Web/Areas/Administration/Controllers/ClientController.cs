namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

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
            var result = clients.ToDataSourceResult(
                request,
                client => new { client.Id, client.EIK, client.Name, client.Address });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Create([DataSourceRequest] DataSourceRequest request, Client client)
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
        public ActionResult Clients_Update([DataSourceRequest] DataSourceRequest request, Client client)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Client
                                 {
                                     Id = client.Id,
                                     EIK = client.EIK,
                                     Name = client.Name,
                                     Address = client.Address
                                 };

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
        public ActionResult Clients_Destroy([DataSourceRequest] DataSourceRequest request, Client client)
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