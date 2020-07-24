using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DretBlog.Data.DatabaseContexts.AuthenticationDbContext;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DretBlog.Web.Services
{
    public class PostsServices : IPostsServices
    {
        private readonly AuthenticationDbContext _context;

        public PostsServices(AuthenticationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogContent> GetAll()
        {
            return _context.BlogContent;
        }

        public string GetAuthor(string UserId)
        {
            return _context.Users
            .FirstOrDefault(opt => opt.Id == UserId).FullName;
        }

        public BlogContent GetById(int id)
        {
            return GetAll()
            .FirstOrDefault(post => post.Id == id);
        }

        public BlogContent GetNewPostAsync(string UserId)
        {
            var NewPost = GetAll()
            .Where(opt => opt.UserId == UserId)
            .LastOrDefault();
            return NewPost;
        }
    }
}