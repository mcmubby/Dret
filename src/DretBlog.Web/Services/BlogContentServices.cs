using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using DretBlog.Data.DatabaseContexts.AuthenticationDbContext;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DretBlog.Web.Services
{
    public class BlogContentServices : IBlogContentServices
    {
        private readonly AuthenticationDbContext _context;

        public BlogContentServices(AuthenticationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BlogContent> GetAll()
        {
            
            return _context.BlogContent.Select(opt=> new BlogContent{Title = opt.Title, CreatedAt=opt.CreatedAt, UserId = opt.ApplicationUser.FullName, });
            //return result as IEnumerable<BlogContent>;
            //context.Devices.Where(your conditions here)
      //.Select(d=>new {Id = d.id, Name = d.Name, DeviceTypeName = d.DeviceType.Name});
        }
    }
}