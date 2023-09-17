using Microsoft.AspNetCore.Mvc;
using Sales_Report_Visualization.Services;

namespace Sales_Report_Visualization.Controllers
{
    [ApiController]
    [Route("api/salesdata")]
    public class SalesDataController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public SalesDataController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult GetSalesData(int categoryId, int productId, int brandId)
        {
            var salesData = _dashboardService.GetSalesData(categoryId, productId, brandId);
            return Ok(salesData);
        }
    }
}