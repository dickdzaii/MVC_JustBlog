using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        PostRepository postRepository = new PostRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View(postRepository.GetAll());
        }
        public ActionResult GetPostsByCategory(string urlSlug)
        {
            if (string.IsNullOrEmpty(urlSlug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listPosts = postRepository.GetPostByCategory(urlSlug);
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            ViewBag.Name = categoryRepository.GetByUrlSlug(urlSlug).CategoryName;
            ViewBag.DynamicTitle = ViewBag.Name;
            return View("Index", listPosts);
        }
        public ActionResult Details(int? year, int? month, string title)
        {
            if (!year.HasValue || !month.HasValue || string.IsNullOrEmpty(title))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postDetail = postRepository.Find(year.Value, month.Value, title);
            if (postDetail == null)
            {
                return HttpNotFound();
            }

            postRepository.IncreasePostView(postDetail);
            ViewBag.Name = postDetail.Title;
            return View(postDetail);
        }
        [ActionName("Latest")]
        public ActionResult GetLatestPosts(int? size)
        {
            ViewBag.DynamicTitle = "Latest Posts";
            var listLatestPosts = postRepository.GetLatestPost(size ?? 5);
            return View(listLatestPosts);
        }
        public ActionResult GetPostsByTag(string urlSlug)
        {
            if (string.IsNullOrEmpty(urlSlug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listPosts = postRepository.GetPostsByTag(urlSlug);
            if (listPosts == null)
            {
                return HttpNotFound();
            }
            ViewBag.DynamicTitle = new TagRepository().GetTagByUrlSlug(urlSlug).TagName;
            ViewBag.Name = '#' + ViewBag.DynamicTitle;
            return View("Index", listPosts);
        }
        
        [ChildActionOnly]
        public ActionResult GetMostViewedPosts()
        {
            var listPost = postRepository.GetMostViewedPosts(5);
            return PartialView("_PartialMostViewed",listPost);
        }
        [ChildActionOnly]
        public ActionResult GetTopTags()
        {
            var listTags = new TagRepository().GetPopularTags(10);
            return PartialView("_PartialPopularTag", listTags);
        }
    }
}