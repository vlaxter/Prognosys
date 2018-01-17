using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prognosys.Web.Startup))]
namespace Prognosys.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
