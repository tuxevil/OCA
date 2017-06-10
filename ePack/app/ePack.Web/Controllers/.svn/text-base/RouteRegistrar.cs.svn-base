using System.Web.Mvc;
using System.Web.Routing;

namespace ePack.Web.Controllers
{
    public class RouteRegistrar
    {
        public static void RegisterRoutesTo(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(null, "", new { controller = "Home", action = "Index" });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/default.aspx",                           // URL with parameters
                new { controller = "Home", action = "Index" }  // Parameter defaults
            );

            routes.MapRoute(
                "DefaultWithId",                                              // Route name
                "{controller}/{action}/{id}/default.aspx",                           // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }  // Parameter defaults
            );
        }
    }
}
