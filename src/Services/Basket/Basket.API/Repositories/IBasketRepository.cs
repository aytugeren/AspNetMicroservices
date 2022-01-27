namespace Basket.API.Repositories
{
    #region
    using Basket.API.Entities;
    #endregion

    /// <summary>
    /// The IBasketRepository
    /// </summary>
    public interface IBasketRepository
    {
        /// <summary>
        /// The GetBasket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{T}"/></returns>
        Task<ShoppingCart> GetBasket(string userName);

        /// <summary>
        /// The UpdateBasket
        /// </summary>
        /// <param name="shoppingCart">The <see cref="ShoppingCart"/></param>
        /// <returns>The <seealso cref="Task{T}"/></returns>
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);

        /// <summary>
        /// The DeleteBasket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{T}"/></returns>
        Task DeleteBasket(string userName);
    }
}
