namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTemplate.Services.Web;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}