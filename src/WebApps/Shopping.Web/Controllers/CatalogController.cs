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

        /// <summary>
        /// Catalog Index Page - Summary
        /// </summary>
        /// <param name="seoName">can be improved</param>
        /// <returns></returns>
        [Route("/{seoName}")]
        public async Task<IActionResult> Index(string seoName)
        {
            var model = new IndexModel();
            //// Seoname e gore catalog var mi yok mu kontrol ediyoruz.
            var catalog = await _catalogService.GetCatalogBySeoName(seoName);
            if (catalog == null || catalog.Id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //// Alinan kategoriye gore Urunleri getirtiyoruz.
            var products = await _catalogService.GetProductIdsByCatalogId(catalog.Id);
            if (products == null)
            {
                return RedirectToAction("Index","Home");
            }
            
            //// Kategori Filtreleri Cekiliyor.
            var filters = await _catalogService.GetCatalogFiltersByChosenCatalog(catalog);


            model.Products = products;
            model.Filters = filters;
            return View(model);
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

        public async Task<PartialViewResult> GetFiltersByCategoryId(Dictionary<string, List<PlacedCatalogModel>> filterModel)
        {
            return PartialView(filterModel);
        }

        public async Task<PartialViewResult> GetProducts(string catalogId)
        {
            return PartialView();
        }
    }
}
