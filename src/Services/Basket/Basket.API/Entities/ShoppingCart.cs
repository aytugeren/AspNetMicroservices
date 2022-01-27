namespace Basket.API.Entities
{
    /// <summary>
    /// The ShoppingCart
    /// </summary>
    public class ShoppingCart
    {
        #region Ctors
        /// <summary>
        /// Ctor
        /// </summary>
        public ShoppingCart()
        {

        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        #endregion

        #region Public Entities
        /// <summary>
        /// The gets or sets username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The gets or sets items
        /// </summary>
        public List<ShoppingCartItem> Items { get; set; }

        /// <summary>
        /// The gets total price
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                if (Items != null)
                {
                    foreach (var item in Items)
                    {
                        totalPrice += item.Price * item.Quantity;
                    }
                }

                return totalPrice;
            }
        }

        #endregion
    }
}
