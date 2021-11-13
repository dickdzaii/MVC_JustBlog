namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class CategoryRepository.
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>
    {
        public Category GetByUrlSlug(string urlSlug)
        {
            return table.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }
    }
}
