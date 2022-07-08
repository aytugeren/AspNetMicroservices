namespace Shopping.Web.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? ProductSeoName { get; set; }

        public int ProductVariantIndex { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public string? ProductImage { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public decimal? CampaignPrice { get; set; }

        public string? CampaignType { get; set; }
    }
}
