using DretBlog.Web.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
//scam plenty for the action below. I have no idea what I just wrote???
        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            return RedirectToAction("CreatedPost", "Post", model);
            
        }
    }
}