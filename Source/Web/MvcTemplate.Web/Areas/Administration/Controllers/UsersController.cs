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
    using Microsoft.AspNet.Identity;

    using MvcTemplate.Data;
    using MvcTemplate.Web.Areas.Administration.ViewModels;

    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult ApplicationUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ApplicationUser> applicationusers = db.Users;
            DataSourceResult result = applicationusers.ToDataSourceResult(request, c => new UsersViewModel 
            {
                Id = c.Id,
                AuthorName = c.AuthorName,
                Email = c.Email
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Create([DataSourceRequest]DataSourceRequest request, UsersViewModel applicationUser)
        {
            if (ModelState.IsValid)
            {
                var entity = new ApplicationUser
                {
                    AuthorName = applicationUser.AuthorName,
                    Email = applicationUser.Email
                };

                db.Users.Add(entity);
                db.SaveChanges();
                applicationUser.Id = entity.Id;
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest]DataSourceRequest request, UsersViewModel applicationUser)
        {
            
                var entity = new ApplicationUser
                {
                    Id = applicationUser.Id,
                    AuthorName = applicationUser.AuthorName,
                    Email = applicationUser.Email,
                    UserName = applicationUser.Email
                };

                db.Users.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy([DataSourceRequest]DataSourceRequest request, UsersViewModel applicationUser)
        {
              var entity = new ApplicationUser
                {
                    Id = applicationUser.Id,
                    AuthorName = applicationUser.AuthorName,
                    Email = applicationUser.Email,
                    UserName = applicationUser.Email
                };

                db.Users.Attach(entity);
                db.Users.Remove(entity);
                db.SaveChanges();
            

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
