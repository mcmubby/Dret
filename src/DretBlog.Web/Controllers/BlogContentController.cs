using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    [Route("/Blog")]
    public class BlogContentController : Controller
    
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}