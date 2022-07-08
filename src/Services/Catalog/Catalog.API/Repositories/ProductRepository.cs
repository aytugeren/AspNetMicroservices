namespace Catalog.API.Repositories
{
    #region
    using Catalog.API.Data;
    using Catalog.API.Entities;
    using MongoDB.Driver;
    #endregion

    /// <summary>
    /// The ProductRepository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        #region Defines Injection
        private readonly ICatalogContext _context;
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">The <see cref="ICatalogContext"/></param>
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        #region Public Methods
        /// <summary>
        /// The Create Product
        /// </summary>
        /// <param name="product">The <see cref="Model"/></param>
        /// <returns>The <seealso cref="Task"/></returns>
        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        /// <summary>
        /// The Delete Product
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{Boolean}"/></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// The Get Product By Id
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{Model}"/></returns>
        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The Get Product By Name
        /// </summary>
        /// <param name="name">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{IEnumerable{T}}"/></returns>
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            // Creating Filter 
            //Eq like operation = ElemMatch not it
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();
        }

        /// <summary>
        /// The Get Products
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{T}}"/></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(prop => true).ToListAsync();
        }

        /// <summary>
        /// The Update Product
        /// </summary>
        /// <param name="product">The <see cref="Model"/></param>
        /// <returns>The <seealso cref="Task{Boolean}"/></returns>
        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        #endregion
    }
}
