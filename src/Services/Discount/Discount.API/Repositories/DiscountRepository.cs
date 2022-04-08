namespace Discount.API.Repositories
{
    #region
    using Discount.API.Entities;
    using Npgsql;
    using Dapper;
    #endregion

    /// <summary>
    /// The Discount Repository
    /// </summary>
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The CreateDiscount
        /// </summary>
        /// <param name="coupon">The <seealso cref="Coupon"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The DeleteDiscount
        /// </summary>
        /// <param name="productName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{Boolean}"/></returns>
        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                    (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The GetDiscount
        /// </summary>
        /// <param name="productName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{T}"/></returns>
        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @Productname", new { Productname = productName });

            if (coupon == null)
            {
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }

            return coupon;
        }

        /// <summary>
        /// The UpdateDiscount
        /// </summary>
        /// <param name="coupon">The <seealso cref="Coupon"/></param>
        /// <returns>The <see cref="Task{Boolean}"/></returns>
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id = @Id",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }
    }
}
