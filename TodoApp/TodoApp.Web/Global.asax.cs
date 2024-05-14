using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Routing;
using TodoApp.Data.Models;
using TodoApp.Data.Repositories;

namespace TodoApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register types
            builder.RegisterType<TodoRepository>().As<ITodoRepository>();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
