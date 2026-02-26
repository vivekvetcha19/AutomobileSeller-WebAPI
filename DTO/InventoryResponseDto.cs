namespace AutomobileSeller.DTOs
{
    public class InventoryResponseDto
    {
        public int Id { get; set; }

        public int CarModelId { get; set; }

        public string CarModelName { get; set; } = string.Empty;

        public int QuantityInStock { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}