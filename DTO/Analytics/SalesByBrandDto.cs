namespace AutomobileSeller.DTO.Analytics
{
    public class SalesByBrandDto
    {
        public string BrandName { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
        public int TotalUnitsSold { get; set; }
    }
}