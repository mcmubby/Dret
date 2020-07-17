using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DretBlog.Data.Entities
{
    public class BlogContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Category")]
        public int TagId { get; set; }
        

        [Display(Name = "Author")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Tags Tags { get; set; }
    }
}