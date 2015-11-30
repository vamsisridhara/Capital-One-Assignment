using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using GFFIAdmin.Models;
using Autofac.Integration.WebApi;
using System.Reflection;
using GFFIAdmin.Repository;

namespace GFFIAdmin
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutoFac(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
        void RegisterAutoFac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Register types
            builder.RegisterType<CustomerAutofacRepository>().As<ICustomerAutofacRepository>();

            builder.RegisterType<GenericRepository<Employee>>().As<IGenericRepository<Employee>>();

            builder.RegisterType<GenericRepository<Customer>>().As<IGenericRepository<Customer>>();

            builder.RegisterType<LobRepository>().As<ILobRepository>();

            builder.RegisterType<PortfolioRepository>().As<IPortfolioRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                        
        }
    }
}
