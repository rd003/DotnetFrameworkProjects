using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TodoApp.Data.Models;
using TodoApp.Data.Repositories;

namespace TodoApp.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register types
            builder.RegisterType<TodoRepository>().As<ITodoRepository>();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            // Set Autofac as the dependency resolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
