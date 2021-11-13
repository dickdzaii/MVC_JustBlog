namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// ICommentRepository interface.
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// Find comment by id.
        /// </summary>
        /// <param name="id">Comment id.</param>
        /// <returns>Comment that match or null.</returns>
        Comment Find(int id);

        /// <summary>
        /// Add comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        void AddComment(Comment comment);

        /// <summary>
        /// Add comment by attributes.
        /// </summary>
        /// <param name="postID">Post id.</param>
        /// <param name="commentName">Comment name.</param>
        /// <param name="commentEmail">Comment email.</param>
        /// <param name="commentTitle">Comment header.</param>
        /// <param name="commentBody">Comment body.</param>
        void AddComment(int postID, string commentName, string commentEmail, string commentTitle, string commentBody);

        /// <summary>
        /// Update comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        void UpdateComment(Comment comment);

        /// <summary>
        /// Delete comment by comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        void DeleteComment(Comment comment);

        /// <summary>
        /// Delete comment by id.
        /// </summary>
        /// <param name="commentID">Comment id.</param>
        void DeleteComment(int commentID);

        /// <summary>
        /// Get all comments.
        /// </summary>
        /// <returns>List of comments.</returns>
        IList<Comment> GetAllComments();

        /// <summary>
        /// Get comments by post id.
        /// </summary>
        /// <param name="postID">post id.</param>
        /// <returns>List of comments.</returns>
        IList<Comment> GetCommentsForPost(int postID);

        /// <summary>
        /// Get comments by Post.
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>List of comments.</returns>
        IList<Comment> GetCommentsForPost(Post post);
    }
}
