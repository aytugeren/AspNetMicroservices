using Newtonsoft.Json;
using Shopping.Web.Extensions;
using Shopping.Web.Models;

namespace Shopping.Web.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// All Categories Fetched
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PlacedCatalogModel>> GetCatalogs()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetCatalogs");
                var responseToModel = JsonConvert.DeserializeObject<List<PlacedCatalogModel>>(response);
                return responseToModel;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Categories are fethed by placing for home page
        /// </summary>
        /// <param name="placeEnum"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContentCatalogModel>> GetContentCatalogsByPlaceEnum(string placeEnum)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetContentCatalogs/" + placeEnum);
                var responseToModel = JsonConvert.DeserializeObject<List<ContentCatalogModel>>(response);
                return responseToModel.OrderBy(x => x.DisplayOrder);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// The Catalog Fetched By Seoname to Search Or Catalog Pages
        /// </summary>
        /// <param name="seoName"></param>
        /// <returns></returns>
        public async Task<PlacedCatalogModel> GetCatalogBySeoName(string seoName)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetCatalogBySeoName/" + seoName);
                var reponseToModel = JsonConvert.DeserializeObject<PlacedCatalogModel>(response);
                return reponseToModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// After GetCatalogBySeoName this method will be worked by this.
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductModel>> GetProductIdsByCatalogId(string catalogId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/Catalog/GetCatalogAndProductsById/"+ catalogId);
                var productIds = JsonConvert.DeserializeObject<List<CatalogProductMappingModel>>(response).FirstOrDefault();
                if (productIds != null && productIds.Products.Any())
                {
                    var responseOfProduct = await _httpClient.PostAsJson("/Catalog/GetProductsByIds", productIds.Products);
                    var responseOfProductDeserialize = await responseOfProduct.ReadContentAs<List<ProductModel>>();
                    return responseOfProductDeserialize;
                }

                return default(IEnumerable<ProductModel>);

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// The Catalog Filters Determine in this method.
        /// </summary>
        /// <param name="catalogModel"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, List<PlacedCatalogModel>>> GetCatalogFiltersByChosenCatalog(PlacedCatalogModel catalogModel)
        {
            ////Tum kataloglar cekiliyor.
            var response = await _httpClient.GetStringAsync("/Catalog/GetCatalogs");
            var responseForCatalogs = JsonConvert.DeserializeObject<List<PlacedCatalogModel>>(response);

            ////Filtreler place lerine gore gruplanarak gonderilecek
            Dictionary<string, List<PlacedCatalogModel>> filters = new Dictionary<string,  List<PlacedCatalogModel>>();

            if (string.IsNullOrEmpty(catalogModel.CatalogParentIndex))
            {
                List<PlacedCatalogModel> models = new List<PlacedCatalogModel>();

                //// Eger kategori 1. Level ise bunun altinda bulunan kataloglar bulunuyor.
                var subCatalogs = responseForCatalogs.Where(x => x.CatalogParentIndex == catalogModel.CatalogIndex).GroupBy(x => x.CatalogPlace).ToList();
                //// Filtreler ekleniyor.
                filters.Add("Header", new List<PlacedCatalogModel> { new PlacedCatalogModel() { CatalogName = catalogModel.CatalogName, CatalogSeoName = catalogModel.CatalogSeoName }  });
                subCatalogs.ForEach(x => filters.Add(x.Key, new List<PlacedCatalogModel>()).ToList()));
            }
            else
            {
                //// Ana Kategori Bulunuyor.
                var parentCatalog = responseForCatalogs.Where(x => x.CatalogIndex == catalogModel.CatalogParentIndex).FirstOrDefault();

                if (parentCatalog != null)
                {
                    //// Sub Kategoriler Bulunuyor..
                    var subCatalogsOfParentCatalog = responseForCatalogs.Where(x => x.CatalogIndex == parentCatalog.CatalogIndex).GroupBy(x => x.CatalogPlace).ToList();

                    //// Kategoriler ekleniyor.
                    filters.Add("Header", new List<string> { catalogModel.CatalogName });
                    subCatalogsOfParentCatalog.ForEach(x => filters.Add(x.Key, x.Select(y => y.CatalogName).ToList()));
                }
            }

            return filters;
        }
    }
}
