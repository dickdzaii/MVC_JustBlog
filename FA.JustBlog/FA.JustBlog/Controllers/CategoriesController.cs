using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult GetAllCategories()
        {
            return PartialView("_CategoriesPartial",categoryRepository.GetAll());
        }
    }
}