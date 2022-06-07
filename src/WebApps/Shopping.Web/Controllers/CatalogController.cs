using Microsoft.AspNetCore.Mvc;

namespace Shopping.Web.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetHomeBarCatalog()
        {
            return PartialView();
        }

        public PartialViewResult GetHomeContent()
        {
            return PartialView();
        }
    }
}
