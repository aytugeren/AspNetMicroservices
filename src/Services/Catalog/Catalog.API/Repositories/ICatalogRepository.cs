namespace Catalog.API.Repositories
{
    using Catalog.API.Entities;

    public interface ICatalogRepository
    {
        Task<IEnumerable<Catalog>> GetCatalogs();

        Task<IEnumerable<ContentCatalog>> GetContentCatalogs();

        Task<IEnumerable<ContentCatalog>> GetContentCatalogByPlace(string placeEnum);

        Task<IEnumerable<CatalogProductMapping>> GetCatalogProductMappings(string catalogId);

        Task<IEnumerable<Product>> GetProductByIds(List<string>? ids);

        Task<Catalog> GetCatalogBySeoName(string seoName);

        Task<ContentCatalog> AdminGetContentCatalogById(string id);
    }
}
