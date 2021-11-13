using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FA.JustBlog.CustomHelper
{
    public static class CategoryHelper
    {
        public static MvcHtmlString CategoryLink(this HtmlHelper htmlHelper,Category category, object htmlAttribute=null)
        {
            return LinkExtensions.ActionLink(htmlHelper,category.CategoryName,"GetPostsByCategory",new { urlSlug =category.UrlSlug}, htmlAttribute);
        }
    }
}