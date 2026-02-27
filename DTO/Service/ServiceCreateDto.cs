using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO.Service
{
    public class ServiceCreateDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CarModelId is required.")]
        public int CarModelId { get; set; }

        [Required(ErrorMessage = "Service description is required.")]
        [MaxLength(500, ErrorMessage = "Service description cannot exceed 500 characters.")]
        public string ServiceDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Service cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Service cost must be greater than 0.")]
        public decimal ServiceCost { get; set; }
    }
}