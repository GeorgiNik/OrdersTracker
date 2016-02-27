namespace OredersTracker.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using OredersTracker.Data;
    using OredersTracker.Data.Common;
    using OredersTracker.Services.Data.Contracts;
    using OredersTracker.Services.Web;
    using OredersTracker.Web.Controllers;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new ApplicationDbContext()).As<DbContext>().InstancePerRequest();
            builder.Register(x => new HttpCacheService()).As<ICacheService>().InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(IClientService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>)).As(typeof(IDbRepository<>)).InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>()
                .PropertiesAutowired();
        }
    }
}