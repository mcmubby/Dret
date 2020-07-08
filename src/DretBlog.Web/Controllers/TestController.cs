using Microsoft.AspNetCore.Mvc;

namespace DretBlog.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}