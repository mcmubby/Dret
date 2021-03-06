using System.Collections.Generic;
using System.Threading.Tasks;
using DretBlog.Data.Entities;

namespace DretBlog.Web.Interfaces
{
    public interface IPostsServices
    {
        public IEnumerable<BlogContent> GetAll();
        public BlogContent GetNewPostAsync(string UserId);
        public BlogContent GetById(int id);
        public string GetAuthor(string UserId);
    }
}