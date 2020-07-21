using System.Collections.Generic;
using JW;

namespace DretBlog.Web.Models.Blog
{
    public class BlogViewModel
    {
        public IEnumerable<PostsList> Posts { get; set; }
        public Pager Pager { get; set; }
        public IEnumerable<PostsList> PagedPost { get; set; }

        
    }
}