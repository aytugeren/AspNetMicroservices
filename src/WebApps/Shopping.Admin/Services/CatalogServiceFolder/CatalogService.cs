using Shopping.Admin.Extension;
using Shopping.Admin.Models;

namespace Shopping.Admin.Services.CatalogServiceFolder
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ContentCatalogModel>> GetContentCatalogsByPlaceAsync(string place)
        {
            var response = await _httpClient.GetAsync($"/Catalog/GetContentCatalogs/{place}");
            var reason = await response.ReadContentAs<List<ContentCatalogModel>>();
            return reason;
        }
    }
}
