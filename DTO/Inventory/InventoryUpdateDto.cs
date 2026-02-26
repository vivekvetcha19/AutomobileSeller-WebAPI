using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO.Inventory
{
    public class InventoryUpdateDto
    {
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int? QuantityInStock { get; set; }
    }
}