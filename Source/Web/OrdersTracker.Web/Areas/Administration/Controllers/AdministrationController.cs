namespace OrdersTracker.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using OrdersTracker.Common;
    using OrdersTracker.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}