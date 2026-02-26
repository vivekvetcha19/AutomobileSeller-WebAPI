namespace AutomobileSeller.DTO
{
    public class BrandResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
