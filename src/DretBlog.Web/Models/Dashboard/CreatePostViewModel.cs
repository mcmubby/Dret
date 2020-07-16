using System;

namespace DretBlog.Web.Models.Dashboard
{
    public class CreatePostViewModel
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TagId { get; set; }
        
        public Guid UserId { get; set; }
    }
}