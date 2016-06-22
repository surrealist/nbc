using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NBC.Web.Startup))]
namespace NBC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
