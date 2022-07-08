namespace Shopping.Web.Models
{
    public class CatalogProductMappingModel
    {
        public string? Id { get; set; }

        public string? CatalogId { get; set; }

        public List<string>? Products { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
