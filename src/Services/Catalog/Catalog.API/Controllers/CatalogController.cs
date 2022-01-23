namespace Catalog.API.Controllers
{
    #region
    using Catalog.API.Entities;
    using Catalog.API.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    #endregion

    /// <summary>
    /// The CatalogController
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        #region Injection Private
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;
        #endregion

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        #region Public Methods

        /// <summary>
        /// The GetProducts
        /// </summary>
        /// <returns><seealso cref="Task{IEnumerable{T}}"/></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        /// <summary>
        /// The GetProductByid
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// The GetProductyCategory
        /// </summary>
        /// <param name="category">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = await _repository.GetProductByCategory(category);
            return Ok(product);
        }

        /// <summary>
        /// The CreateProduct
        /// </summary>
        /// <param name="product">The <see cref="Model"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id: length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
        #endregion
    }
}
