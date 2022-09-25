using Microsoft.AspNetCore.Mvc;

namespace Shopping.Admin
{
    public class DashboardHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetDashboardMenu()
        {
            return PartialView();
        }
    }
}
