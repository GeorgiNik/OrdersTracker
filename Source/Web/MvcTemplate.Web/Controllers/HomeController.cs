namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        //private readonly ICommentService comments;

        //private readonly IIdeaService ideas;

        //private const int ItemsPerPage = 3;
        //public HomeController(ICommentService comments, IIdeaService ideas)
        //{
        //    this.comments = comments;
        //    this.ideas = ideas;
        //}

        public ActionResult Index(int id = 1)
        {
            return this.View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PostIdea(IndexViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(model);
        //    }
        //    var idea = new Idea { Title = model.Idea.Title, Description = model.Idea.Description };
        //    if (this.User.Identity.IsAuthenticated)
        //    {
        //        idea.AuthorId = this.User.Identity.GetUserId();
        //    }
        //    this.ideas.CreateIdea(idea);
        //    this.TempData["Notification"] = "Thank your for your idea!";
        //    return this.Redirect("/");

        // }
    }
}