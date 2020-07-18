using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsServices _postservice;

        public PostController(IPostsServices postservice)
        {
            _postservice = postservice;
        }
        [HttpGet]
        public IActionResult NewPost(PostViewModel model)
        {
            var post = _postservice.GetNewPostAsync();
            model.Content = post.Content ;
            model.Title = post.Title;
            model.CreatedAt = post.CreatedAt;
            ViewBag.Poststr = model.Content;
            ViewBag.Title = model.Title;
            ViewBag.CreatedAt = model.CreatedAt.ToString("MM/dd/yyyy");
            ViewBag.Author = model.Author;
            return View();
        }
    }
}