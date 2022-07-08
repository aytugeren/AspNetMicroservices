using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;
using Shopping.Web.Services.Catalog;
using System.Diagnostics;

namespace Shopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalogService _catalogService;

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public PartialViewResult GetHeader()
        {
            return PartialView();
        }

        public PartialViewResult GetHomeSlider()
        {
            return PartialView();
        }

        public PartialViewResult GetHomeBar()
        {
            return PartialView();
        }

        public async Task<PartialViewResult> GetSlider()
        {
            var sliders = await _catalogService.GetContentCatalogsByPlaceEnum("Header");
            return PartialView(sliders);
        }

        public PartialViewResult GetFooter()
        {
            return PartialView();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}