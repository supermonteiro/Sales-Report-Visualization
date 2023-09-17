using Microsoft.AspNetCore.Mvc;
using Sales_Report_Visualization.Services;

namespace Sales_Report_Visualization.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public BrandsController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult GetBrands(int productId, int categoryId)
        {
            var brands = _dashboardService.GetBrands(productId, categoryId);
            return Ok(brands);
        }
    }
}