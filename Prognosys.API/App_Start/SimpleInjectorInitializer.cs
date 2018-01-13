using Prognosys.Core;
using Prognosys.Repository.Sql.Repositories;
using Prognosys.Shared.Interfaces.Repositories;
using Prognosys.Shared.Interfaces.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Prognosys.API.App_Start
{
    class SimpleInjectorInitializer
    {
        /// <summary>
        ///     Initializes injector
        /// </summary>
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
            
            container.Register<IProjectsService, ProjectsService>(Lifestyle.Scoped);
            container.Register<IProjectsRepository, ProjectsRepository>(Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}