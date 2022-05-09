namespace Basket.API.Controllers
{
    using AutoMapper;
    #region
    using Basket.API.Entities;
    using Basket.API.GrpcServices;
    using Basket.API.Repositories;
    using EventBus.Messages.Events;
    using MassTransit;
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
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="discountGrpcService"></param>
        /// <param name="mapper"></param>
        /// <param name="publishEndpoint"></param>
        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
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
            // TODO : Communicate with Discount.Grpc
            // and Calculate latest prices of product into shopping cart
            // consume Discount Grpc

            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

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

        /// <summary>
        /// The Checkout
        /// </summary>
        /// <param name="basketCheckout">The <see cref="BasketCheckout"/></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            // get existing basket with total price
            var basket = await _repository.GetBasket(basketCheckout.UserName);
            if (basket == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

           //Remove the basket
           await _repository.DeleteBasket(basket.UserName);

            return Accepted();
        }
    }
}
