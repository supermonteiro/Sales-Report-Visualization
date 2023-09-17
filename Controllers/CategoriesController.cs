using Microsoft.AspNetCore.Mvc;
using Sales_Report_Visualization.Services;

namespace Sales_Report_Visualization.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public CategoriesController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _dashboardService.GetCategories();
            return Ok(categories);
        }
    }
}