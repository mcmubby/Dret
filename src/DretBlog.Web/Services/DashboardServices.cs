using System;
using System.Threading.Tasks;
using DretBlog.Data.DatabaseContexts.AuthenticationDbContext;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Dashboard;
using Microsoft.AspNetCore.Identity;


namespace DretBlog.Web.Services
{
    public class DashboardServices : IDashboardServices
    {
        private readonly AuthenticationDbContext _context;

        public DashboardServices(AuthenticationDbContext context)
        {
            _context = context;
            
        }
        
        public BlogContent CreateNewPostAsync(CreatePostViewModel model)
        {
            var post = new BlogContent{
                ApplicationUser = model.ApplicationUser,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.Now.Date,
                UserId = model.UserId,
                TagId = 1,
            };
            _context.Add(post);
            _context.SaveChanges();

            return post;
        }
    }
}