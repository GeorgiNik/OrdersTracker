namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult InternalError()
        {
            return this.View();
        }
    }
}