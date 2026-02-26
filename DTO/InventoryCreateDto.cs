using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTOs
{
    public class InventoryCreateDto
    {
        [Required(ErrorMessage = "CarModelId is required.")]
        public int? CarModelId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int? QuantityInStock { get; set; }
    }
}