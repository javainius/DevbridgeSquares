using DevbridgeSquares.App;
using DevbridgeSquares.Core.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DevbridgeSquares.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();


            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IApplication, Application>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}