using System.ComponentModel.DataAnnotations;

namespace DretBlog.Web.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}