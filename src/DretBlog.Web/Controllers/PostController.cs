using DretBlog.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult CreatedPost(PostViewModel model)
        {
            ViewBag.Poststr = model.Content;
            ViewBag.Title = model.Title;
            ViewBag.CreatedAt = model.CreatedAt;
            return View();
        }
    }
}