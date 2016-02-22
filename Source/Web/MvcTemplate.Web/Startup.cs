using Microsoft.Owin;

using MvcTemplate.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace MvcTemplate.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
