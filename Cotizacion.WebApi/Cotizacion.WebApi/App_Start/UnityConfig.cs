using Cotizacion.Core.Concretes;
using Cotizacion.Core.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Cotizacion.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICotizacionStrategyFactory, CotizacionStrategyFactory>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}