using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private JustBlogContext blogContext;
        protected DbSet<T> table;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        public BaseRepository()
        {
            this.blogContext = new JustBlogContext();
            this.table = this.blogContext.Set<T>();
        }

        public bool Create(T obj)
        {
            try
            {
                this.table.Add(obj);
                blogContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T obj)
        {
            try
            {
                this.blogContext.Entry(obj).State = EntityState.Deleted;
                blogContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(object id)
        {
            return this.table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.table;
        }

        public bool Update(T obj)
        {
            try
            {
                this.blogContext.Entry(obj).State = EntityState.Modified;
                blogContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            this.blogContext.Dispose();
        }

        public bool Delete(object id)
        {
            T obj = this.table.Find(id);
            try
            {
                this.blogContext.Entry(obj).State = EntityState.Deleted;
                blogContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            blogContext.SaveChanges();
        }
    }
}
