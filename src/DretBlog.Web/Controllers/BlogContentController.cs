using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class BlogContentController : Controller
    
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}