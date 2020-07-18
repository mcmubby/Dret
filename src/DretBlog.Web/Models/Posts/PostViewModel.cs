using System;

namespace DretBlog.Web.Models.Posts
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TagId { get; set; }
        
        public string Author { get; set; }
        public string UserId { get; set; }
    }
}