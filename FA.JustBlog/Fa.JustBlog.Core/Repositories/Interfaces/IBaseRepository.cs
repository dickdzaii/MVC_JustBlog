using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        bool Create(T obj);

        bool Update(T obj);

        bool Delete(T obj);

        bool Delete(object id);

        T Find(object id);

        IQueryable<T> GetAll();
    }
}
