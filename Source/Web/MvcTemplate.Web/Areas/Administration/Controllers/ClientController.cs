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

namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using MvcTemplate.Data.Common;

    public class ClientController : Controller
    {
        private IDbRepository<Client> clients;

        public ClientController(IDbRepository<Client> clients)
        {
            this.clients = clients;
        } 

        public ActionResult Clients()
        {
            return this.View();
        }

        public ActionResult Clients_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Client> clients = this.clients.All();
            DataSourceResult result = clients.ToDataSourceResult(request, client => new {
                Id = client.Id,
                EIK = client.EIK,
                Name = client.Name,
                Address = client.Address,
                
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Create([DataSourceRequest]DataSourceRequest request, Client client)
        {
            if (ModelState.IsValid)
            {
                var entity = new Client
                {
                    EIK = client.EIK,
                    Name = client.Name,
                    Address = client.Address,
                    
                };

                this.clients.Add(entity);
                this.clients.Save();
                client.Id = entity.Id;
            }

            return Json(new[] { client }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Update([DataSourceRequest]DataSourceRequest request, Client client)
        {
            if (ModelState.IsValid)
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
           
            

            return Json(new[] { client }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients_Destroy([DataSourceRequest]DataSourceRequest request, Client client)
        {
            
                var entity = new Client
                {
                    Id = client.Id,
                    EIK = client.EIK,
                    Name = client.Name,
                    Address = client.Address,
                  
                };

                this.clients.HardDelete(entity);
                this.clients.Save();
            

            return Json(new[] { client }.ToDataSourceResult(request, ModelState));
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

        
    }
}
