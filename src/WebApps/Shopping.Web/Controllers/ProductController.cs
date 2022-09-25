using Microsoft.AspNetCore.Mvc;

namespace Shopping.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string url)
        {
            return View();
        }
    }
}
