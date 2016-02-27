namespace OrdersTracker.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using OrdersTracker.Services.Web;
    using OrdersTracker.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}