namespace Discount.Grpc.Repositories
{
    #region
    using Discount.Grpc.Entities;
    #endregion

    /// <summary>
    /// The IDiscount Repository
    /// </summary>
    public interface IDiscountRepository
    {
        /// <summary>
        /// The GetDiscount By Product name
        /// </summary>
        /// <param name="productName">The <see cref="string"/></param>
        /// <returns><see cref="Task{T}"/></returns>
        Task<Coupon> GetDiscount(string productName);

        /// <summary>
        /// The CreateDiscount
        /// </summary>
        /// <param name="coupon">The <see cref="Coupon"/></param>
        /// <returns><see cref="bool"/></returns>
        Task<bool> CreateDiscount(Coupon coupon);

        /// <summary>
        /// The UpdateDiscount
        /// </summary>
        /// <param name="coupon">The <see cref="Coupon"/></param>
        /// <returns><see cref="bool"/></returns>
        Task<bool> UpdateDiscount(Coupon coupon);

        /// <summary>
        /// The DeleteDiscount
        /// </summary>
        /// <param name="productName">The <see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        Task<bool> DeleteDiscount(string productName);
    }
}
