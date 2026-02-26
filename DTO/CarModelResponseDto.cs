namespace AutomobileSeller.DTOs
{
    public class CarModelResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;
    }
}
