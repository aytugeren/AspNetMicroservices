 namespace Catalog.API.Data
{
    #region
    using Catalog.API.Entities;
    using MongoDB.Driver;
    #endregion

    /// <summary>
    /// The ICatalogContext
    /// </summary>
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }

        IMongoCollection<Catalog> Catalogs { get; }

        IMongoCollection<ContentCatalog> ContentCatalogs { get; }

        IMongoCollection<CatalogProductMapping> CatalogProductMappings { get; }
    }
}