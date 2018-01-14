using Prognosys.API.App_Start;
using System.Web.Http;

namespace Prognosys.API
{
    /// <summary>
    /// Web Api application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application start
        /// </summary>
        protected void Application_Start()
        {
            SimpleInjectorInitializer.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
