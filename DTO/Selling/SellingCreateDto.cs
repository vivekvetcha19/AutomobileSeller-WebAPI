using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO.Selling
{
    public class SellingCreateDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CarModelId is required.")]
        public int CarModelId { get; set; }

        [Required(ErrorMessage = "QuantitySold is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int QuantitySold { get; set; }

        [Required(ErrorMessage = "SellingPrice is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Selling price must be greater than 0.")]
        public decimal SellingPrice { get; set; }
    }
}