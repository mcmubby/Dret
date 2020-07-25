using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DretBlog.Data.Entities;

namespace DretBlog.Web.Models.Dashboard
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TagId { get; set; }
        
        public string Author { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Tags Tags { get; set; }

        public IEnumerable<UserTitles> UserPostTitles { get; set; }
    }
}