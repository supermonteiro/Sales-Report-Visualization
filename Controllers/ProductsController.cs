using Microsoft.AspNetCore.Mvc;
using Sales_Report_Visualization.Services;

namespace Sales_Report_Visualization.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public ProductsController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult GetProducts(int categoryId)
        {
            var products = _dashboardService.GetProducts(categoryId);
            return Ok(products);
        }
    }
}