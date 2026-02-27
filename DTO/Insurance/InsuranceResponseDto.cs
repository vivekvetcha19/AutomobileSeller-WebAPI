namespace AutomobileSeller.DTO.Insurance
{
    public class InsuranceResponseDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CarModelName { get; set; } = string.Empty;

        public string PolicyNumber { get; set; } = string.Empty;

        public string ProviderName { get; set; } = string.Empty;

        public decimal CoverageAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}