using System;
using System.Collections;

namespace DretBlog.Data.Entities
{
    public class BlogContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TagId { get; set; }
        public Tags Tags { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}