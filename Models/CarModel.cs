namespace AutomobileSeller.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int BrandId { get; set; }  // Foreign Key

        public Brand Brand { get; set; }  // Navigation Property
    }
}
