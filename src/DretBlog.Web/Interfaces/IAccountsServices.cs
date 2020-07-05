using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Models.Accounts;

namespace DretBlog.Web.Interfaces
{
    public interface IAccountsServices
    {
        Task<ApplicationUser> CreateUserAsync(RegisterViewModel model);
    }
}