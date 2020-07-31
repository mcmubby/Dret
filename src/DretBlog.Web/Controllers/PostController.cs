using System.Threading.Tasks;
using DretBlog.Data.Entities;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    [Authorize]
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
        [Route("/{controller}/{id}")]
        public IActionResult GetPost(int id)
        {
            var result = _postservice.GetById(id);
            var model = new PostViewModel{
                Title = result.Title,
                Content = result.Content,
                CreatedAt = result.CreatedAt,
                UserId = result.UserId,
                Id = result.Id
            };
            model.Author = _postservice.GetAuthor(model.UserId);
            
            ViewBag.Poststr = model.Content;
            return View(model);
        }
    }
}