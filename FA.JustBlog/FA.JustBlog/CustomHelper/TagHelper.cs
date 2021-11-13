using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FA.JustBlog.CustomHelper
{
    public static class TagHelper
    {
        public static MvcHtmlString TagLink(this HtmlHelper htmlHelper,Tag tag, object htmlAttribute=null)
        {
            return LinkExtensions.ActionLink(htmlHelper, tag.TagName, "GetPostsByTag", new { urlSlug = tag.UrlSlug }, htmlAttribute);
        }
    }
}