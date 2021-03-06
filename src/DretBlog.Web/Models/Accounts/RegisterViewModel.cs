using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DretBlog.Web.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Fullname")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}