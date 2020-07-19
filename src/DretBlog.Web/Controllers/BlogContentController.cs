using System.Linq;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    [Route("/Blog")]
    public class BlogContentController : Controller
    {
        private readonly IBlogContentServices _blogContent;

        public BlogContentController(IBlogContentServices blogContent)
        {
            _blogContent = blogContent;
        }
        public IActionResult Index()
        {
            var AllPosts = _blogContent.GetAll();
            var sortPosts = AllPosts.Select(result => new PostsList
            {
                Title = result.Title,
                CreatedAt = result.CreatedAt.ToString("MM/dd/yyyy"),
                Author = result.UserId
                
            });
            var model = new BlogViewModel(){
                Posts = sortPosts
            };
            return View(model);
        }

        
    }
}