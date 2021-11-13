using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using PagedList;
using MVCGrid.Web;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    {
        private JustBlogContext db = new JustBlogContext();
        private PostRepository postRepository = new PostRepository();

        // GET: Admin/Posts
        [Authorize(Roles = "Contributor, User,Blog Owner")]
        public ActionResult Index()
        {
            var posts = postRepository.GetAll();
            return View(posts.ToList());
        }

        // GET: Admin/Posts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,ShortDescription,PostContent,UrlSlug,Published,PostedOn,Modified,CategoryID,ViewCount,RateCount,TotalRate")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UrlSlug = post.Title.GenerateSlug();
                postRepository.Create(post);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ShortDescription,PostContent,UrlSlug,Published,PostedOn,Modified,CategoryID,ViewCount,RateCount,TotalRate")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UrlSlug = post.Title.GenerateSlug();
                postRepository.Update(post);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        [Authorize(Roles = "Blog Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = postRepository.Find(id);
            postRepository.Delete(post);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult GetLatestPosts(int? size)
        {
            size = size ?? 5;
            var listPosts = postRepository.GetLatestPost(size.Value);
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            return View(listPosts);
        }
        [AllowAnonymous]
        public ActionResult GetMostViewedPosts(int? size)
        {
            size = size ?? 5;
            var listPosts = postRepository.GetMostViewedPosts(size.Value);
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            return View(listPosts);
        }
        [AllowAnonymous]
        public ActionResult GetMostInterestingPosts(int? size)
        {
            size = size ?? 5;
            var listPosts = postRepository.GetHighestPosts(size.Value);
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            return View(listPosts);
        }
        public ActionResult GetPublishedPosts()
        {
            var listPosts = postRepository.GetPublishedPost();
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            return View(listPosts);
        }

        public ActionResult GetUnpublishedPosts()
        {
            var listPosts = postRepository.GetUnpublishedPost();
            if (listPosts == null)
            {
                return HttpNotFound();
            }

            return View(listPosts);
        }

        public ActionResult Paging(int index = 1, int size = 10)
        {
            var listPosts = postRepository.GetAll().OrderBy(p => p.ID);
            return View(listPosts.ToPagedList(index, size));
        }

        [Authorize(Roles ="Blog Owner")]
        public ActionResult PublishPost(int id)
        {
            Post post = postRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            if (post.Published)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            post.Published = true;
            postRepository.Update(post);
            return RedirectToAction("Index", "Posts");
        }

        [Authorize(Roles = "Blog Owner")]
        public ActionResult UnublishPost(int id)
        {
            Post post = postRepository.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            if (!post.Published)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            post.Published = false;
            postRepository.Update(post);
            return RedirectToAction("Index", "Posts");
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
