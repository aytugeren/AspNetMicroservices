using Shopping.Admin.Extension;
using Shopping.Admin.Models;

namespace Shopping.Admin.Services.OrderServiceFolder
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient client)
        {
           _httpClient = client;
        }

        public async Task<DashboardResponseModel> GetTotalDataForDashboard()
        {
            var response = await _httpClient.GetAsync($"/Order/GetOrderByUserName/All");
            var reason = await response.ReadContentAs<List<OrderResponseModel>>();
            var dashboardModel = new DashboardResponseModel();

            dashboardModel.TotalAmount = reason.Select(x => x.TotalPrice).Sum();
            dashboardModel.Profit = default(decimal);
            dashboardModel.TotalRefund = 0;
            dashboardModel.TotalSale = reason.Count();
           

            return dashboardModel;
        }
    }
}
