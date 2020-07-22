using System.Collections.Generic;
using DretBlog.Data.Entities;
using DretBlog.Web.Models.Blog;
using JW;

namespace DretBlog.Web.Interfaces
{
    public interface IBlogContentServices
    {
        public IEnumerable<BlogContent> GetAll();
       // public BlogContent GetNewPostAsync(string UserId);
       public IEnumerable<PostsList> PageData(Pager Pager, IEnumerable<PostsList> Posts);
       public Pager CurrentPageSetter(int p, IEnumerable<PostsList> Posts);
    }
}