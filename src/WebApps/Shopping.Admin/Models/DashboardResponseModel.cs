namespace Shopping.Admin.Models
{
    public class DashboardResponseModel
    {
        public decimal? Profit { get; set; }

        public int TotalSale { get; set; }

        public int TotalRefund { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
