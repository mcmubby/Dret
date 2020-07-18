using DretBlog.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DretBlog.Data.DatabaseContexts.AuthenticationDbContext
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<BlogContent> BlogContent { get; set; }
    }
}