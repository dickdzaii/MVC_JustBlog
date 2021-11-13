namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Interface ITagRepository.
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Find tag.
        /// </summary>
        /// <param name="tagID">Tag id.</param>
        /// <returns>Tag.</returns>
        Tag Find(int tagID);

        void AddTag(Tag tag);

        void UpdateTag(Tag tag);

        void DeleteTag(Tag tag);

        void DeleteTag(int tagID);

        IList<Tag> GetAllTags();

        Tag GetTagByUrlSlug(string urlSlug);
    }
}
