using System.ComponentModel.DataAnnotations;

namespace AutomobileSeller.DTO
{
    public class BrandCreateDto
    {
        [Required(ErrorMessage = "Brand name is required.")]
        [MaxLength(100, ErrorMessage = "Brand name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(100, ErrorMessage = "Country cannot exceed 100 characters.")]
        public string Country { get; set; } = string.Empty;
    }
}
