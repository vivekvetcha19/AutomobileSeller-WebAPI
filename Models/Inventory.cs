namespace AutomobileSeller.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int CarModelId { get; set; }   // Foreign Key

        public CarModel CarModel { get; set; } = null!;

        public int QuantityInStock { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}