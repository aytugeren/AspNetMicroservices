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

        public async Task<IEnumerable<ContentCatalog>> GetContentCatalogByPlace(string placeEnum)
        {
            // Creating Filter 
            //Eq like operation = ElemMatch not it
            FilterDefinition<Entities.ContentCatalog> filter = Builders<Entities.ContentCatalog>.Filter.Eq(p => p.Place, placeEnum);

            return await _catalogContext.ContentCatalogs.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ContentCatalog>> GetContentCatalogs()
        {
            var contentCatalogs = await _catalogContext.ContentCatalogs.Find(prop => true).ToListAsync();
            return contentCatalogs;
        }

        public async Task<IEnumerable<CatalogProductMapping>> GetCatalogProductMappings(string catalogId)
        {

            FilterDefinition<Entities.CatalogProductMapping> filter = Builders<Entities.CatalogProductMapping>.Filter.Eq(p => p.CatalogId, catalogId);
            return await _catalogContext.CatalogProductMappings.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByIds(List<string>? ids)
        {
            var productsByIds = await _catalogContext.Products.Find(x => ids.Contains(x.Id)).ToListAsync();
            return productsByIds;
        }

        public async Task<Entities.Catalog> GetCatalogBySeoName(string? seoName)
        {
            var catalog = await _catalogContext.Catalogs.Find(x => x.CatalogSeoName.Contains(seoName)).FirstOrDefaultAsync();
            if (catalog == null)
            {
                return new Entities.Catalog();
            }
            else
            {
                return catalog;
            }
        }
    }
}
