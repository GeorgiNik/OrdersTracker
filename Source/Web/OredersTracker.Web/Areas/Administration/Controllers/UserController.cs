namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using OredersTracker.Common;
    using OredersTracker.Data;
    using OredersTracker.Data.Models;
    using OredersTracker.Web.Areas.Administration.ViewModels;
    using OredersTracker.Web.Controllers;
    using OredersTracker.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UserController : BaseController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult ApplicationUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<ApplicationUser> applicationusers = this.db.Users;
            var result = applicationusers.To<UsersViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest] DataSourceRequest request, UsersViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.db.Users.FirstOrDefault(x => x.Id == model.Id);
                entity.AuthorName = model.AuthorName;
                entity.Email = model.Email;
                entity.UserName = model.Email;

                this.db.Users.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }
            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy(
            [DataSourceRequest] DataSourceRequest request,
            UsersViewModel applicationUser)
        {
            var entity = this.Mapper.Map<ApplicationUser>(applicationUser);

            this.db.Users.Attach(entity);
            this.db.Users.Remove(entity);
            this.db.SaveChanges();

            return this.Json(
                new[]
                    {
                        applicationUser
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
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}