using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ICatalogContext _catalogContext;

        public CatalogRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<IEnumerable<Entities.Catalog>> GetCatalogs()
        {
            var catalogs = await _catalogContext.Catalogs.Find(prop => true).ToListAsync();
            return catalogs;
        }

        public async Task<IEnumerable<Entities.ContentCatalog>> GetContentCatalogByPlace(string placeEnum)
        {
            // Creating Filter 
            //Eq like operation = ElemMatch not it
            FilterDefinition<Entities.ContentCatalog> filter = Builders<Entities.ContentCatalog>.Filter.Eq(p => p.Place, placeEnum);

            return await _catalogContext.ContentCatalogs.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.ContentCatalog>> GetContentCatalogs()
        {
            var contentCatalogs = await _catalogContext.ContentCatalogs.Find(prop => true).ToListAsync();
            return contentCatalogs;
        }
    }
}
