using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Posts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsServices _postservice;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(IPostsServices postservice, 
            UserManager<ApplicationUser> userManager)
        {
            _postservice = postservice;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> NewPost(PostViewModel model)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var post = _postservice.GetNewPostAsync(CurrentUser.Id);
            model.Content = post.Content ;
            model.Title = post.Title;
            model.CreatedAt = post.CreatedAt;
            model.Author = CurrentUser.FullName;
            ViewBag.Poststr = model.Content;
            return View(model);
        }

        public IActionResult GetPost(int id, PostViewModel model)
        {
            var result = _postservice.GetById(id);
            model.Title = result.Title;
            model.Content = result.Content;
            model.CreatedAt = result.CreatedAt;
            model.UserId = result.UserId;
            //fix username
            model.Author = _postservice.GetAuthor(model.UserId);
            model.Id = result.Id;
            
            ViewBag.Poststr = model.Content;
            return View(model);
        }
    }
}