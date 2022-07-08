namespace Shopping.Web.Models
{
    public class IndexModel
    {
        public IEnumerable<ProductModel> Products { get; set; }

        public Dictionary<string, List<string>> Filters { get; set; }
    }
}
