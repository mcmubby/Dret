using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Models.Dashboard;

namespace DretBlog.Web.Interfaces
{
    public interface IDashboardServices
    {
        BlogContent CreateNewPostAsync(CreatePostViewModel model);
    }
}