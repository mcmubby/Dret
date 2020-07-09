using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DretBlog.Data.Entities
{
    public class Tags
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }

        public ICollection<BlogContent> BlogContents { get; set; }
    }
}