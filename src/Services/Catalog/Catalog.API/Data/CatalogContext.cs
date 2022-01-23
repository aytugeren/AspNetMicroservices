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
            CatalogContextSeed.SeedData(Products);
        }

        /// <summary>
        /// The Collection of MongoDb ProductDb
        /// </summary>
        public IMongoCollection<Product> Products { get; }
    }
}
