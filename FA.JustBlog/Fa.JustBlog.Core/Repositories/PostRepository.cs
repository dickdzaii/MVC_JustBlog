namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class PostRepository.
    /// </summary>
    public class PostRepository : BaseRepository<Post>
    {
        private readonly JustBlogContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        public PostRepository()
        {
            this.blogContext = new JustBlogContext();
        }

        public new IQueryable<Post> GetAll()
        {
            var listPosts = blogContext.Posts.Include("Tags").Include("Category").Include("Comments");
            return listPosts;
        }

        /// <summary>
        /// Count posts by category.
        /// </summary>
        /// <param name="category">Category name.</param>
        /// <returns>Number of posts that match.</returns>
        public int CountPostByCategory(string category)
        {
            return this.blogContext.Posts.Where(p => p.Category.CategoryName == category).Count();
        }

        /// <summary>
        /// Find post by year and mont published and url slug.
        /// </summary>
        /// <param name="year">Year published.</param>
        /// <param name="month">Month published.</param>
        /// <param name="urlSlug">Post's url slug.</param>
        /// <returns>Post or null.</returns>
        public Post Find(int year, int month, string urlSlug)
        {
            if (!int.TryParse(month.ToString(), out month)
                || month > 12 || month < 0)
            {
                throw new Exception("Invalid month");
            }

            if (!int.TryParse(year.ToString(), out year) || year < 0)
            {
                throw new Exception("Invalid year");
            }

            var post = this.GetAll().
                FirstOrDefault(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
            return post;
        }

        /// <summary>
        /// Get latest post.
        /// </summary>
        /// <param name="size">Number of posts.</param>
        /// <returns>List of posts.</returns>
        public IList<Post> GetLatestPost(int size)
        {
            if (size < 0)
            {
                throw new Exception("Invalid size");
            }

            return this.GetAll()
                .OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        /// <summary>
        /// Get posts by category.
        /// </summary>
        /// <param name="category">Category url slug.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostByCategory(string category)
        {
            var listPost = this.GetAll().Where(p => p.Category.UrlSlug == category).ToList();
            return listPost;
        }

        /// <summary>
        /// Get posts by month published.
        /// </summary>
        /// <param name="month">Post's month published.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostByMonth(int month)
        {
            if (month > 12 || month < 0)
            {
                throw new Exception("Invalid month");
            }

            return this.GetAll().Where(p => p.PostedOn.Month == month).ToList();
        }

        /// <summary>
        /// Get all published posts.
        /// </summary>
        /// <returns>List published posts.</returns>
        public IList<Post> GetPublishedPost()
        {
            return this.GetAll().Where(p => p.Published).ToList();
        }

        /// <summary>
        /// Get all unpublished posts.
        /// </summary>
        /// <returns>List unpublished posts.</returns>
        public IList<Post> GetUnpublishedPost()
        {
            return this.GetAll().Where(p => !p.Published).ToList();
        }

        /// <summary>
        /// Count posts that have the tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>Number of posts that match.</returns>
        public int CountPostsForTag(string tag)
        {
            var matchTag = this.blogContext.Tags.FirstOrDefault(t => t.TagName == tag);
            return this.blogContext.Posts.Where(p => p.Tags == matchTag).Count();
        }

        /// <summary>
        /// Get all posts that have the tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostsByTag(string tag)
        {
            return this.GetAll().Where(p => p.Tags.Any(s => s.UrlSlug == tag)).ToList();
        }

        /// <summary>
        /// Get most view posts by size.
        /// </summary>
        /// <param name="size">number of posts.</param>
        /// <returns>List of most viewed posts.</returns>
        public IList<Post> GetMostViewedPosts(int size)
        {
            var mostViewedPosts = this.blogContext.Posts.
                OrderByDescending(p => p.ViewCount).Take(size).ToList();
            return mostViewedPosts;
        }

        /// <summary>
        /// Get highest posts by ssize.
        /// </summary>
        /// <param name="size">number of posts.</param>
        /// <returns>List of highest posts.</returns>
        public IList<Post> GetHighestPosts(int size)
        {
            var highestPosts = this.blogContext.Posts.OrderByDescending(p => p.Rate).Take(size).ToList();
            return highestPosts;
        }

        public Post GetByUrlSlug(string urlSlug)
        {
            return this.table.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public void IncreasePostView(Post post)
        {
            post.ViewCount++;
            this.blogContext.SaveChanges();
        }
    }
}
