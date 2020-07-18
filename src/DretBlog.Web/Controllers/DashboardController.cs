using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Dashboard;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }
//scam plenty for the action below. I have no idea what I just wrote???
        [HttpPost]
        public async Task<IActionResult> CreateNewPost(CreatePostViewModel model)
        {
            model.ApplicationUser = await _userManager.GetUserAsync(User);
            model.UserId = model.ApplicationUser.Id;
            model.Author = model.ApplicationUser.FullName;
            var post = _dashboard.CreateNewPostAsync(model);
            // return RedirectToAction("NewPost", "Post", post);
            return RedirectToAction("NewPost", "Post");

            
        }
    }
}