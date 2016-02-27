namespace OredersTracker.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using OredersTracker.Common;
    using OredersTracker.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}