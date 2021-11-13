namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// IPostRepository interface.
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Create post.
        /// </summary>
        /// <param name="post">New post.</param>
        void CreatePost(Post post);

        /// <summary>
        /// Update post.
        /// </summary>
        /// <param name="post">Post.</param>
        void UpdatePost(Post post);

        /// <summary>
        /// Delete post by post.
        /// </summary>
        /// <param name="post">Post.</param>
        void DeletePost(Post post);

        /// <summary>
        /// Delete post by id.
        /// </summary>
        /// <param name="postID">Post id.</param>
        void DeletePost(int postID);

        /// <summary>
        /// Find post by id.
        /// </summary>
        /// <param name="postID">Post id.</param>
        /// <returns>Post that match or null.</returns>
        Post FindPost(int postID);

        /// <summary>
        /// Find post by url and year, month publish.
        /// </summary>
        /// <param name="year">Year publish.</param>
        /// <param name="month">Month publish.</param>
        /// <param name="urlSlug">Post's url.</param>
        /// <returns>Post that match or null.</returns>
        Post FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// Get all posts.
        /// </summary>
        /// <returns>List of post.</returns>
        IList<Post> GetAllPost();

        /// <summary>
        /// Get published posts.
        /// </summary>
        /// <returns>List of published posts.</returns>
        IList<Post> GetPublishedPost();

        /// <summary>
        /// Get unpulished posts.
        /// </summary>
        /// <returns>List of unpublished posts.</returns>
        IList<Post> GetUnpublishedPost();

        /// <summary>
        /// Get posts by month.
        /// </summary>
        /// <param name="month">Month posted posts.</param>
        /// <returns>List posts.</returns>
        IList<Post> GetPostByMonth(int month);

        /// <summary>
        /// Get latest posts by size.
        /// </summary>
        /// <param name="size">Number of posts.</param>
        /// <returns>List of latest posts.</returns>
        IList<Post> GetLatestPost(int size);

        /// <summary>
        /// Count posts by category.
        /// </summary>
        /// <param name="category">Category name.</param>
        /// <returns>Number of posts by category.</returns>
        int CountPostByCategory(string category);

        /// <summary>
        /// Get posts by category.
        /// </summary>
        /// <param name="category">Category name.</param>
        /// <returns>List of posts by category.</returns>
        IList<Post> GetPostByCategory(string category);

        /// <summary>
        /// Count posts for tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>Number of posts for tag.</returns>
        int CountPostsForTag(string tag);

        /// <summary>
        /// Get all posts by tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>List of post by tag.</returns>
        IList<Post> GetPostsByTag(string tag);

        /// <summary>
        /// Get most viewed posts.
        /// </summary>
        /// <param name="size">size.</param>
        /// <returns>List of most viewed posts.</returns>
        IList<Post> GetMostViewedPosts(int size);

        /// <summary>
        /// Get most highest posts.
        /// </summary>
        /// <param name="size">size.</param>
        /// <returns>List of highest posts.</returns>
        IList<Post> GetHighestPosts(int size);
    }
}
