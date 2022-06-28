using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;
using Shopping.Web.Services.Catalog;

namespace Shopping.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> GetHomeBarCatalog()
        {
            var catalogs = await _catalogService.GetCatalogs();

            return PartialView(catalogs);
        }

        public async Task<PartialViewResult> GetHomeContent()
        {
            var sliders = await _catalogService.GetContentCatalogsByPlaceEnum("HeaderSub");
            return PartialView(sliders);
        }

        public PartialViewResult GetHomePageSellersBar()
        {
            return PartialView();
        }
    }
}
