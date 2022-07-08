namespace Catalog.API.Data
{
    #region
    using Catalog.API.Entities;
    using MongoDB.Driver;
    #endregion
    
    /// <summary>
    /// The CatalogContext
    /// </summary>
    public class CatalogContext : ICatalogContext
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration">The see <paramref name="configuration"/>.</param>
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            Catalogs = database.GetCollection<Catalog>(configuration.GetValue<string>("DatabaseSettings:CollectionNameCatalog"));
            ContentCatalogs = database.GetCollection<ContentCatalog>(configuration.GetValue<string>("DatabaseSettings:CollectionNameContentCatalog"));
            CatalogProductMappings = database.GetCollection<CatalogProductMapping>(configuration.GetValue<string>("DatabaseSettings:CollectionNameCatalogProductMapping"));
            CatalogContextSeed.SeedData(Products, Catalogs, ContentCatalogs, CatalogProductMappings);
        }

        /// <summary>
        /// The Collection of MongoDb ProductDb
        /// </summary>
        public IMongoCollection<Product> Products { get; }
        
        public IMongoCollection<ContentCatalog> ContentCatalogs { get; }

        public IMongoCollection<Catalog> Catalogs { get; }

        public IMongoCollection<CatalogProductMapping> CatalogProductMappings { get; }
    }
}
