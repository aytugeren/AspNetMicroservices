namespace Catalog.API.Repositories
{
    #region
    using Catalog.API.Entities;
    #endregion

    /// <summary>
    /// The IProductRepository
    /// </summary>
    public interface IProductRepository
    {
        #region Public Methods
        /// <summary>
        /// The Get Products
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{T}}"/></returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// The Get Product By Id
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{Model}"/>.</returns>
        Task<Product> GetProduct(string id);

        /// <summary>
        /// The Get Product By Name
        /// </summary>
        /// <param name="name">The <see cref="string"/>.</param>
        /// <returns>The <seealso cref="Task{IEnumerable{T}}"/>.</returns>
        Task<IEnumerable<Product>> GetProductByName(string name);

        /// <summary>
        /// The Get Product By Category Name
        /// </summary>
        /// <param name="categoryName">The <see cref="string"/>.</param>
        /// <returns>The <seealso cref="Task{IEnumerable{T}}"/>.</returns>
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        /// <summary>
        /// The Create Product
        /// </summary>
        /// <param name="product">The <see cref="Model"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task CreateProduct(Product product);

        /// <summary>
        /// The Update Product
        /// </summary>
        /// <param name="product">The <see cref="Model"/></param>
        /// <returns>The <seealso cref="Task{Boolean}"/></returns>
        Task<bool> UpdateProduct(Product product);

        /// <summary>
        /// The Delete Product
        /// </summary>
        /// <param name="id">The <see cref="string"/>.</param>
        /// <returns>The <seealso cref="Task{Boolean}"/></returns>
        Task<bool> DeleteProduct(string id);
        #endregion
    }
}
