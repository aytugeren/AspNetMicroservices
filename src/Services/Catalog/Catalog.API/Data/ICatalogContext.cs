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
    }
}