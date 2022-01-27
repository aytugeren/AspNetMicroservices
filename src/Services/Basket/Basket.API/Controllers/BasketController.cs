﻿namespace Basket.API.Controllers
{
    #region
    using Basket.API.Entities;
    using Basket.API.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    #endregion

    /// <summary>
    /// The Basket Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository">The <see cref="IBasketRepository"/></param>
        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// The Get Basket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task{ActionResult{ShoppingCart}}"/></returns>
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        /// <summary>
        /// The Update Basket
        /// </summary>
        /// <param name="basket">The <see cref="ShoppingCart"/></param>
        /// <returns>The <seealso cref="Task{TResult}"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
        }

        /// <summary>
        /// The Delete Basket
        /// </summary>
        /// <param name="userName">The <see cref="string"/></param>
        /// <returns>The <seealso cref="Task"/></returns>
        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }
    }
}