namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OredersTracker.Common;
    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Web.Areas.Administration.ViewModels;
    using OredersTracker.Web.Controllers;
    using OredersTracker.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult ApplicationUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = this.userService.All().To<UsersViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest] DataSourceRequest request, UsersViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (model.IsAdmin)
                {
                    this.userService.MakeAdmin(model.Id);
                }
                else
                {
                    this.userService.RemoveAdmin(model.Id);
                }
                var user = this.Mapper.Map<ApplicationUser>(model);
                this.userService.Update(user);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy(
            [DataSourceRequest] DataSourceRequest request,
            UsersViewModel applicationUser)
        {
            var entity = this.Mapper.Map<ApplicationUser>(applicationUser);
            this.userService.Remove(entity);

            return this.Json(new[] { applicationUser }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            byte[] fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            byte[] fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}