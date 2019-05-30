using InternationalizationApp.BLL.Services;
using InternationalizationApp.DAL;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace InternationalizationApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IGitHubService, GitHubService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(typeof(Context)));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}