using System.Collections.Generic;
using System.Linq;
using DretBlog.Web.Interfaces;
using DretBlog.Web.Models.Blog;
using JW;
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

        [HttpGet]
        public IActionResult Index(int p = 1)
        {
            var AllPosts = _blogContent.GetAll();
            var sortPosts = AllPosts.Select(result => new PostsList
            {
                Title = result.Title,
                Author = result.UserId,
                CreatedAt = result.CreatedAt.ToString("MM/dd/yyyy"),
                
                
            });
            var model = new BlogViewModel(){
                Posts = sortPosts,
                
            };
            
            var PageSet = SetPage(p,model.Posts);
            var testpages = Pagination(PageSet,model.Posts);
            model.Pager = PageSet;
            model.PagedPost = testpages;

            

            // // get pagination info for the current page
            // Pager = new Pager(dummyItems.Count(), p, PageSize, MaxPages);

            // // assign the current page of items to the Items property
            // Items = dummyItems.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);
            return View(model);
        }
        public IEnumerable<PostsList> Pagination(Pager Pager, IEnumerable<PostsList> Posts)
        {
           var PagedPost = Posts.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);
           return PagedPost;
        }

        public Pager SetPage(int p, IEnumerable<PostsList> Posts)
        {
            var Pager = new Pager(Posts.Count(), p ,5, ((Posts.Count())/5));
            return Pager;
        }

        
    }
}