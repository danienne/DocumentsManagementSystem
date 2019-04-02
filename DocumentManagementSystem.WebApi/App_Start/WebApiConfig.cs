using DocumentManagementSystem.Business.Business;
using DocumentManagementSystem.Contracts.Business;
using DocumentManagementSystem.Contracts.Repository;
using DocumentManagementSystem.Repository.Repository;
using DocumentManagementSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace DocumentManagementSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IDocumentsBusiness, DocumentsBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<IDocumentsRepository, DocumentsRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
