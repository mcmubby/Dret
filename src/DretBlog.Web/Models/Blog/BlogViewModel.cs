using System.Collections.Generic;

namespace DretBlog.Web.Models.Blog
{
    public class BlogViewModel
    {
        public IEnumerable<PostsList> Posts { get; set; }
    }
}