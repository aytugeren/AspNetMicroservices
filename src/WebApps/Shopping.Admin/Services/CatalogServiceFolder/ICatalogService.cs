using Shopping.Admin.Models;

namespace Shopping.Admin.Services.CatalogServiceFolder
{
    public interface ICatalogService
    {
        Task<List<ContentCatalogModel>> GetContentCatalogsByPlaceAsync(string place);
    }
}
