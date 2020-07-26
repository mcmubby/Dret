using System.Linq;
using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDashboardServices _dashboard;

        
        public DashboardController(UserManager<ApplicationUser> userManager,
            IDashboardServices dashboard)
        {
            _userManager = userManager;
            _dashboard = dashboard;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CreatePostViewModel model)
        {
            model.ApplicationUser = await _userManager.GetUserAsync(User);
            model.UserId = model.ApplicationUser.Id;
            var UserPostDetails = _dashboard.GetUserPost(model.UserId);
            var sortTitle = UserPostDetails.Select(result => new UserTitles{
                Title = result.Title,
                CreatedAt = result.CreatedAt
            });
            model.UserPostTitles = sortTitle;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost(CreatePostViewModel model)
        {   
            model.ApplicationUser = await _userManager.GetUserAsync(User);
            var post = _dashboard.CreateNewPostAsync(model);
            var id = post.Id;
            //return RedirectToAction("GetPost", "Post", post.Id);
            return RedirectToRoute(new {
                controller = "Post",
                action = "GetPost",
                id = id
            });
        }
    }
}