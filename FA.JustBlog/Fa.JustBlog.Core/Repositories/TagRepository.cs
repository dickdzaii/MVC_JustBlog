namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class TagRepository to implements ITagRepository's methods.
    /// </summary>
    public class TagRepository : BaseRepository<Tag>
    {
        private readonly JustBlogContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagRepository"/> class.
        /// </summary>
        public TagRepository()
        {
            this.blogContext = new JustBlogContext();
        }

        /// <summary>
        /// Add tag to DBContext.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public bool AddTag(Tag tag)
        {
            //// if tag contain two space, can't add
            if (tag.TagName.Contains("  "))
            {
                return false;
            }

            //// make tag url by tag name.
            tag.UrlSlug = tag.TagName.Replace(" ", "-") + "tag";
            try
            {
                this.Create(tag);
                this.blogContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Get tag by url slug.
        /// </summary>
        /// <param name="urlSlug">Tag's url.</param>
        /// <returns>Single tag or null.</returns>
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return this.blogContext.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public IQueryable<Tag> GetPopularTags(int size)
        {
            var listTags = blogContext.Tags.Include("Posts").OrderByDescending(s => s.Posts.Count).Take(size);
            return listTags;
        }
    }
}
