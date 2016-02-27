using Microsoft.Owin;

using OrdersTracker.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace OrdersTracker.Web
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