using AutomobileSeller.DTO.Analytics;

namespace AutomobileSeller.Services
{
    public interface IAnalyticsService
    {
        Task<RevenueDto> GetTotalRevenueAsync();
        Task<IEnumerable<SalesByBrandDto>> GetSalesByBrandAsync();
        Task<IEnumerable<TopSellingModelDto>> GetTopSellingModelsAsync(int top);
        Task<IEnumerable<LowStockDto>> GetLowStockAsync(int threshold);
    }
}