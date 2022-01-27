namespace Basket.API.Entities
{
    /// <summary>
    /// The ShoppingCartItem
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// The gets or sets quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The gets or sets color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The gets or sets price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The gets or sets productid
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// The gets or sets productname
        /// </summary>
        public string ProductName { get; set; }
    }
}
