using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Admin.Models;
using Shopping.Admin.Services.OrderServiceFolder;

namespace Shopping.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOrderService _orderService;

        public IndexModel(ILogger<IndexModel> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;

        }

        public DashboardResponseModel DashboardContent { get; set; } = new DashboardResponseModel();

        public async Task<IActionResult> OnGet()
        {
            DashboardContent = await _orderService.GetTotalDataForDashboard();
            return Page();
        }
    }
}