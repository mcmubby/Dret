using System;
using DretBlog.Data.Entities;

namespace DretBlog.Web.Models.Dashboard
{
    public class CreatePostViewModel
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TagId { get; set; }
        
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}