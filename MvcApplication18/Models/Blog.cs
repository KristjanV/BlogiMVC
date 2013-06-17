using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication18.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string pealkiri { get; set; }
        public DateTime kuupaev { get; set; }
        public string sisu { get; set; }
    }
    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}