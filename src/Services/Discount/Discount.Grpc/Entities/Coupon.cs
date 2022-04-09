namespace Discount.Grpc.Entities
{
    /// <summary>
    /// The Coupon
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public int Amount { get; set; }
    }
}
