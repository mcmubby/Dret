using System.Collections.Generic;
using DretBlog.Data.Entities;

namespace DretBlog.Web.Interfaces
{
    public interface IBlogContentServices
    {
        public IEnumerable<BlogContent> GetAll();
       // public BlogContent GetNewPostAsync(string UserId);
    }
}