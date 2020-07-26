using System.Collections.Generic;
using System.Linq;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Blog;
using JW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    [Authorize]
    [Route("/Blog")]
    public class BlogContentController : Controller
    {
        private readonly IBlogContentServices _blogContent;

        public BlogContentController(IBlogContentServices blogContent)
        {
            _blogContent = blogContent;
        }

        [HttpGet]
        public IActionResult Index(int p = 1)
        {
            var AllPosts = _blogContent.GetAll();
            var sortPosts = AllPosts.Select(result => new PostsList
            {
                Title = result.Title,
                Author = result.UserId,
                CreatedAt = result.CreatedAt.ToString("MM/dd/yyyy"),
                Id = result.Id
                
            });
            var model = new BlogViewModel(){
                Posts = sortPosts
            };
            
            var PageSet = _blogContent.CurrentPageSetter(p,model.Posts);
            var PagedContent = _blogContent.PageData(PageSet,model.Posts);
            model.Pager = PageSet;
            model.PagedPost = PagedContent;

            return View(model);
        }
        
    }
}