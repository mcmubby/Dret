using System.Collections.Generic;
using System.Linq;
using DretBlog.Data.DatabaseContexts.AuthenticationDbContext;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using JW;
using DretBlog.Web.Models.Blog;

namespace DretBlog.Web.Services
{
    public class BlogContentServices : IBlogContentServices
    {
        private readonly AuthenticationDbContext _context;

        public BlogContentServices(AuthenticationDbContext context)
        {
            _context = context;
        }

        public Pager CurrentPageSetter(int p, IEnumerable<PostsList> Posts)
        {
            var Pager = new Pager(Posts.Count(), p ,5, ((Posts.Count())/5));
            return Pager;
        }

        public IEnumerable<BlogContent> GetAll()
        {
            
            return _context.BlogContent
            .Select(opt=> new BlogContent{
                Id = opt.Id, 
                Title = opt.Title, 
                CreatedAt=opt.CreatedAt, 
                UserId = opt.ApplicationUser.FullName
            }).OrderByDescending(opt => opt.CreatedAt);
            
        }

        public IEnumerable<PostsList> PageData(Pager Pager, IEnumerable<PostsList> Posts)
        {
            var PagedPost = Posts.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);
            return PagedPost;
        }
        
    }
}