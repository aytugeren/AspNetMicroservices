using MediatR;
using Ordering.Application.Features.Orders.Models;

namespace Ordering.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrdersVm>>
    {
        public GetAllOrdersQuery()
        {
        }
    }
}
