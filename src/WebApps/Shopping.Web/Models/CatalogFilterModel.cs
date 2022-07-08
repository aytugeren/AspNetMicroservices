namespace Shopping.Web.Models
{
    public class CatalogFilterModel
    {
        public int Id { get; set; }

        public string? FacetName { get; set; }

        public int FacetIndex { get; set; }

        public string? FacetCatalogIndex { get; set; }

        public string? FacetSeoName { get; set; }
    }
}
