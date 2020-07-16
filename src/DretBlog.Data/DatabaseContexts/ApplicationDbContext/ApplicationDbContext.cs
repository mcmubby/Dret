using DretBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DretBlog.Data.DatabaseContexts.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
            
        }

        //test code
        
        public DbSet<Tags> Tag { get; set; }
        public DbSet<BlogContent> BlogContents { get; set; }
    }
}