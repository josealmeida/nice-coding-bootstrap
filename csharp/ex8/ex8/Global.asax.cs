using ex8.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace ex8
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //custom dependency resolver
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
        }
    }
}
