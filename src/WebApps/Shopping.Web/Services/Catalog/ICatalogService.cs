using Shopping.Web.Models;
using System.Collections.Generic;

namespace Shopping.Web.Services.Catalog
{
    public interface ICatalogService
    {
        Task<IEnumerable<PlacedCatalogModel>> GetCatalogs();

        Task<IEnumerable<ContentCatalogModel>> GetContentCatalogsByPlaceEnum(string placeEnum);

        Task<PlacedCatalogModel> GetCatalogBySeoName(string seoName);

        Task<IEnumerable<ProductModel>> GetProductIdsByCatalogId(string catalogId);

        Task<Dictionary<string, List<PlacedCatalogModel>>> GetCatalogFiltersByChosenCatalog(PlacedCatalogModel catalogModel);

    }
}
