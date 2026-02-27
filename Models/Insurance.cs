namespace AutomobileSeller.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = null!;

        public string PolicyNumber { get; set; } = string.Empty;

        public string ProviderName { get; set; } = string.Empty;

        public decimal CoverageAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}