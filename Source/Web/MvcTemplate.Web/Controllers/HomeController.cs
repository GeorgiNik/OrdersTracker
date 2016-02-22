namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;

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

        //public ActionResult Index(int id=1)
        //{
        //    var page = id;
            
        //    var allItemsCount = this.ideas.GetAll().Count();
        //    var totalPages = Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
        //    var itemsToSkip = (page - 1) * ItemsPerPage;
        //    var ideasAll = this.ideas.GetAll().OrderByDescending(x=>x.CreatedOn).Skip(itemsToSkip).Take(ItemsPerPage).To<IdeasViewModel>().ToList();
        //    var viewModel = new IndexViewModel()
        //                        {
        //                            Ideas = ideasAll ,
        //                            TotalPages =(int) totalPages,
        //                            CurrentPage = page
                                   
        //                        };
            
        //    return this.View(viewModel);
        //}

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


        //}
        
    }
}