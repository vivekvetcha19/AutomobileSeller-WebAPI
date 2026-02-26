using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO.CarModel
{
    public class CarModelCreateDto
    {
        [Required(ErrorMessage = "Model name is required.")]
        [MaxLength(100, ErrorMessage = "Model name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue,
            ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "BrandId is required.")]
        public int BrandId { get; set; }
    }
}
