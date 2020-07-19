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

        public BlogContent GetNewPostAsync(string UserId)
        {
            var NewPost = GetAll()
            .Where(opt => opt.UserId == UserId)
            .LastOrDefault();
            return NewPost;
        }
    }
}