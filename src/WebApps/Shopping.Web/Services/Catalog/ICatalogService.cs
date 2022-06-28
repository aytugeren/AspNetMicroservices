using Shopping.Web.Models;
using System.Collections.Generic;

namespace Shopping.Web.Services.Catalog
{
    public interface ICatalogService
    {
        Task<IEnumerable<PlacedCatalogModel>> GetCatalogs();

        Task<IEnumerable<ContentCatalogModel>> GetContentCatalogsByPlaceEnum(string placeEnum);

    }
}
