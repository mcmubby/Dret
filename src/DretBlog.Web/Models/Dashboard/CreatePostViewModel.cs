using System;
using System.ComponentModel.DataAnnotations;
using DretBlog.Data.Entities;

namespace DretBlog.Web.Models.Dashboard
{
    public class CreatePostViewModel
    {
        
        public string Title { get; set; }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Category")]
        public int TagId { get; set; }
        
        public string Author { get; set; }

        [Display(Name = "Author")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Tags Tags { get; set; }
    }
}