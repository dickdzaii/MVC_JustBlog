namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Comment Repository.
    /// </summary>
    public class CommentRepository : BaseRepository<Comment>
    {
        /// <summary>
        /// Add comment by attributes.
        /// </summary>
        /// <param name="postID">Post id.</param>
        /// <param name="commentName">Comment name.</param>
        /// <param name="commentEmail">Comment email.</param>
        /// <param name="commentTitle">Comment header.</param>
        /// <param name="commentBody">Comment text.</param>
        /// <returns>True if added, false if add fail.</returns>
        public bool AddComment(int postID, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var newComment = new Comment();
            newComment.PostID = postID;
            newComment.Name = commentName;
            newComment.Email = commentEmail;
            newComment.CommentHeader = commentTitle;
            newComment.CommentText = commentBody;
            newComment.CommentTime = DateTime.Now;
            try
            {
                this.Create(newComment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all post's comments by post id.
        /// </summary>
        /// <param name="postID">Post.</param>
        /// <returns>List of comments.</returns>
        public IList<Comment> GetCommentsForPost(int postID)
        {
            var comments = this.GetAll().Where(c => c.PostID == postID).ToList();
            return comments;
        }

        /// <summary>
        /// Get all post's comments by post.
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>List of comments.</returns>
        public IList<Comment> GetCommentsForPost(Post post)
        {
            var comments = this.GetAll().Where(c => c.Post == post).ToList();
            return comments;
        }
    }
}
