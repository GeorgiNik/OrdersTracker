namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using MvcTemplate.Common;
    using MvcTemplate.Data;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data;

    using MvcTemplate.Web.Controllers;
    using MvcTemplate.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        
    }
}