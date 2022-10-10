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
        private readonly ICatalogRepository _catalogRepository;
        private readonly ILogger<CatalogController> _logger;
        #endregion

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="catalogRepository"></param>
        public CatalogController(IProductRepository repository, ICatalogRepository catalogRepository, ILogger<CatalogController> logger)
        {
            _catalogRepository = catalogRepository;
            _repository = repository;
            _logger = logger;
        }

        #region Public Methods
        #region WebActions
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
        [HttpGet("{id}", Name = "GetProduct")]
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

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }

        /// <summary>
        /// The GetProductyCategory
        /// </summary>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]", Name = "GetCatalogs")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Catalog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetCatalogsFromMongo()
        {
            var catalogs = await _catalogRepository.GetCatalogs();
            return Ok(catalogs);
        }

        [Route("[action]", Name = "GetContentCatalogs")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentCatalog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContentCatalog>>> GetContentCatalog()
        {
            var contentCatalogs = await _catalogRepository.GetContentCatalogs();
            return Ok(contentCatalogs);
        }

        /// <summary>
        /// The GetProductyCategory
        /// </summary>
        /// <param name="placeEnum">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]/{placeEnum}", Name = "GetContentCatalogByPlace")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentCatalog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContentCatalog>>> GetContentCatalogByPlace(string placeEnum)
        {
            var contentCatalogs = await _catalogRepository.GetContentCatalogByPlace(placeEnum);

            return Ok(contentCatalogs);
        }


        /// <summary>
        /// The GetCatalogAndProductsById
        /// </summary>
        /// <param name="catalogId">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]/{catalogId}", Name = "GetCatalogAndProductsById")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CatalogProductMapping>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogProductMapping>>> GetCatalogAndProductsById(string catalogId)
        {
            var catalogAndProducts = await _catalogRepository.GetCatalogProductMappings(catalogId);

            return Ok(catalogAndProducts);
        }

        /// <summary>
        /// The GetCatalogAndProductsById
        /// </summary>
        /// <param name="catalogId">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]/{seoName}", Name = "GetCatalogBySeoName")]
        [HttpGet]
        [ProducesResponseType(typeof(Catalog), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Catalog>> GetCatalogBySeoName(string seoName)
        {
            var catalog = await _catalogRepository.GetCatalogBySeoName(seoName);

            return Ok(catalog);
        }

        /// <summary>
        /// The GetProductsByIds
        /// </summary>
        /// <param name="ids">The <see cref="List{T}"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{T}}"/></returns>
        [Route("[action]", Name = "GetProductsByIds")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByIds(List<string> ids)
        {
            var products = await _catalogRepository.GetProductByIds(ids);
            return Ok(products);
        }
        #endregion
        #region AdminPanelActions

        [Route("[action]", Name = "AdminGetContentCatalogs")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentCatalog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContentCatalog>>> AdminGetContentCatalog()
        {
            var contentCatalogs = await _catalogRepository.GetContentCatalogs();
            return Ok(contentCatalogs);
        }

        [Route("[action]/{id}", Name = "AdminGetContentCatalogById")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentCatalog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContentCatalog>>> AdminGetContentCatalogById(string id)
        {
            var contentCatalogs = await _catalogRepository.AdminGetContentCatalogById(id);
            return Ok(contentCatalogs);
        }
        #endregion
        #endregion
    }
}
