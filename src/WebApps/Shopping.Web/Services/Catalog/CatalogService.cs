using Newtonsoft.Json;
using Shopping.Web.Extensions;
using Shopping.Web.Models;

namespace Shopping.Web.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PlacedCatalogModel>> GetCatalogs()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetCatalogs");
                var responseToModel = JsonConvert.DeserializeObject<List<PlacedCatalogModel>>(response);
                return responseToModel;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<IEnumerable<ContentCatalogModel>> GetContentCatalogsByPlaceEnum(string placeEnum)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetContentCatalogs/" + placeEnum);
                var responseToModel = JsonConvert.DeserializeObject<List<ContentCatalogModel>>(response);
                return responseToModel.OrderBy(x => x.DisplayOrder);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
