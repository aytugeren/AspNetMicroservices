namespace Catalog.API.Repositories
{
    using Catalog.API.Entities;

    public interface ICatalogRepository
    {
        Task<IEnumerable<Catalog>> GetCatalogs();

        Task<IEnumerable<ContentCatalog>> GetContentCatalogs();

        Task<IEnumerable<ContentCatalog>> GetContentCatalogByPlace(string placeEnum);
    }
}
