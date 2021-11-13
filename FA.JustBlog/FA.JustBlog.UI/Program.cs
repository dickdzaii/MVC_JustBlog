using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            JustBlogContext abc = new JustBlogContext();
            var x=abc.Posts.ToList();
            foreach (var item in x)
            {
                Console.WriteLine(item.Published);
            }
            Console.WriteLine("HVD");
            Console.ReadKey();
        }
    }
}
