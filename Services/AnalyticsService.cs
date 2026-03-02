using AutomobileSeller.Data;
using AutomobileSeller.DTO.Analytics;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationDbContext _context;

        public AnalyticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        //  Total Revenue
        public async Task<RevenueDto> GetTotalRevenueAsync()
        {
            var total = await _context.SellingHistories
                .SumAsync(s => s.SellingPrice * s.QuantitySold);

            return new RevenueDto
            {
                TotalRevenue = total
            };
        }

        // Sales by Brand
        public async Task<IEnumerable<SalesByBrandDto>> GetSalesByBrandAsync()
        {
            return await _context.SellingHistories
                .Include(s => s.CarModel)
                .ThenInclude(m => m.Brand)
                .GroupBy(s => s.CarModel.Brand.Name)
                .Select(g => new SalesByBrandDto
                {
                    BrandName = g.Key,
                    TotalRevenue = g.Sum(x => x.SellingPrice * x.QuantitySold),
                    TotalUnitsSold = g.Sum(x => x.QuantitySold)
                })
                .ToListAsync();
        }

        // Top Selling Models
        public async Task<IEnumerable<TopSellingModelDto>> GetTopSellingModelsAsync(int top)
        {
            return await _context.SellingHistories
                .Include(s => s.CarModel)
                .GroupBy(s => s.CarModel.Name)
                .Select(g => new TopSellingModelDto
                {
                    CarModelName = g.Key,
                    UnitsSold = g.Sum(x => x.QuantitySold)
                })
                .OrderByDescending(x => x.UnitsSold)
                .Take(top)
                .ToListAsync();
        }

        // Low Stock
        public async Task<IEnumerable<LowStockDto>> GetLowStockAsync(int threshold)
        {
            return await _context.Inventories
                .Include(i => i.CarModel)
                .Where(i => i.QuantityInStock <= threshold)
                .Select(i => new LowStockDto
                {
                    CarModelName = i.CarModel.Name,
                    QuantityInStock = i.QuantityInStock
                })
                .ToListAsync();
        }
    }
}