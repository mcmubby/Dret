using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DretBlog.Web.Models.Accounts
{
    public class LoginViewModel
    {
        
        [EmailAddress]
        [Required]
        [DisplayName("Email address")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

    
    }
}