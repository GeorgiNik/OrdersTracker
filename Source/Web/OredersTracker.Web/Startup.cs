using Microsoft.Owin;

using OredersTracker.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace OredersTracker.Web
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