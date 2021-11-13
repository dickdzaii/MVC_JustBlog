using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    [Authorize(Roles = "Blog Owner, Contributor")]
    public class BaseController : Controller
    {
        // GET: Admin/Base
        
    }
}