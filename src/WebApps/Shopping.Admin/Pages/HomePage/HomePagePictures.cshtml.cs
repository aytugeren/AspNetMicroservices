using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Admin.Models;
using Shopping.Admin.Services.CatalogServiceFolder;

namespace Shopping.Admin.Pages.HomePage
{
    public class HomePagePicturesModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public HomePagePicturesModel(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public List<ContentCatalogModel> contentCatalogModels { get; set; } = new List<ContentCatalogModel>();

        public async Task<IActionResult> OnGet()
        {
            contentCatalogModels = await _catalogService.GetContentCatalogsByPlaceAsync("Slider");

            return Page();

        }
    }
}
