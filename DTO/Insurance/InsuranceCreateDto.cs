using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO.Insurance
{
    public class InsuranceCreateDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CarModelId is required.")]
        public int CarModelId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        [MaxLength(100, ErrorMessage = "Policy number cannot exceed 100 characters.")]
        public string PolicyNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Provider name is required.")]
        [MaxLength(200, ErrorMessage = "Provider name cannot exceed 200 characters.")]
        public string ProviderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Coverage amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Coverage amount must be greater than 0.")]
        public decimal CoverageAmount { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        public DateTime ExpiryDate { get; set; }
    }
}