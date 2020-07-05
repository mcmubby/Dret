using Microsoft.AspNetCore.Identity;

namespace DretBlog.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}