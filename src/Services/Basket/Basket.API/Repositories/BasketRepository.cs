namespace Basket.API.Repositories
{
    #region
    using Basket.API.Entities;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// The Basket Repository
    /// </summary>
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distrubutedCache;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="distributedCache"></param>
        public BasketRepository(IDistributedCache distributedCache)
        {
            _distrubutedCache = distributedCache;
        }

        /// <summary>
        /// The GetBasket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{T}"/></returns>
        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _distrubutedCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        /// <summary>
        /// The Update Basket
        /// </summary>
        /// <param name="basket">The <see cref="ShoppingCart"/></param>
        /// <returns>The <seealso cref="Task{ShoppingCart}"/></returns>
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _distrubutedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }

        /// <summary>
        /// The Delete Basket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task"/></returns>
        public async Task DeleteBasket(string userName)
        {
            await _distrubutedCache.RemoveAsync(userName);
        }
    }
}
