using Shopping.Admin.Models;

namespace Shopping.Admin.Services.OrderServiceFolder
{
    public interface IOrderService
    {
        Task<DashboardResponseModel> GetTotalDataForDashboard();

    }
}
