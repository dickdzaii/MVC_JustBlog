namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// ICategory Repository interface.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        ///  Find category.
        /// </summary>
        /// <param name="categoryID">category id.</param>
        /// <returns>category or null.</returns>
        Category FindCategory(int categoryID);

        /// <summary>
        /// Create category.
        /// </summary>
        /// <param name="category">Category.</param>
        void CreateCategory(Category category);

        /// <summary>
        /// Update category.
        /// </summary>
        /// <param name="category">Category.</param>
        void UpdateCategory(Category category);

        /// <summary>
        /// Delete category.
        /// </summary>
        /// <param name="categoryID">Category Id.</param>
        void DeleteCategory(int categoryID);

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>All categories</returns>
        IList<Category> GetAllCategories();
    }
}
