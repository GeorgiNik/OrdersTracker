namespace OredersTracker.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using OredersTracker.Services.Web;
    using OredersTracker.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}