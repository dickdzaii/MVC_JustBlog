using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //      routes.MapRoute(
            //    name: "Paging",
            //    url: "Admin/{controller}/{action}/{index}/{size}",
            //    defaults: new { controller = "Posts", action = "Index" },
            //    new string[] { "FA.JustBlog.Areas.Admin.Controllers" }
            //);
          
            routes.MapRoute(
                 name: "Post",
                 url: "Post/{year}/{month}/{title}",
                 defaults: new { controller = "Post", action = "Details" },
                 namespaces: new string[] { "FA.JustBlog.Controllers" }
             );
            routes.MapRoute(
              name: "PostByCategory",
              url: "Category/{urlSlug}",
              defaults: new { controller = "Post", action = "GetPostsByCategory" },
              new string[] { "FA.JustBlog.Controllers" }
          );
            routes.MapRoute(
              name: "PostByTag",
              url: "Tag/{urlSlug}",
              defaults: new { controller = "Post", action = "GetPostsByTag" },
               namespaces: new string[] { "FA.JustBlog.Controllers" }
            );
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}",
              defaults: new { controller = "Post", action = "Index"},
              namespaces: new string[] { "FA.JustBlog.Controllers" }
          );
            routes.MapRoute(
               name: "Admin",
               url: "Admin/{controller}/{action}/{id}",
               defaults: new { controller = "Posts", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "FA.JustBlog.Areas.Admin.Controllers" }
           );
        }
    }
}