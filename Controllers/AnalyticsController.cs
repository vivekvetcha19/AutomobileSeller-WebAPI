using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.DTO.Analytics;
using Microsoft.AspNetCore.Authorization;

namespace AutomobileSeller.Controllers
{
    
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        // Total Revenue
        [HttpGet("total-revenue")]
        public async Task<IActionResult> GetTotalRevenue()
        {
            var result = await _analyticsService.GetTotalRevenueAsync();
            return Ok(result);
        }

        // Sales by Brand
        [HttpGet("sales-by-brand")]
        public async Task<IActionResult> GetSalesByBrand()
        {
            var result = await _analyticsService.GetSalesByBrandAsync();
            return Ok(result);
        }

        // Top Selling Models
        [HttpGet("top-models")]
        public async Task<IActionResult> GetTopModels([FromQuery] int top = 5)
        {
            var result = await _analyticsService.GetTopSellingModelsAsync(top);
            return Ok(result);
        }

        // Low Stock
        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock([FromQuery] int threshold = 5)
        {
            var result = await _analyticsService.GetLowStockAsync(threshold);
            return Ok(result);
        }
    }
}