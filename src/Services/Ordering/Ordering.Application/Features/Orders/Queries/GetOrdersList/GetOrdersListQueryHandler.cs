using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = default(IEnumerable<Order>);
            if (request.Username == "All")
            {
                orderList = await _orderRepository.GetAllOrders();
                return _mapper.Map<List<OrdersVm>>(orderList);
            }
            orderList = await _orderRepository.GetOrdersByUserName(request.Username);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}
