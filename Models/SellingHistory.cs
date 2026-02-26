namespace AutomobileSeller.Models
{
    public class SellingHistory
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = null!;

        public int QuantitySold { get; set; }

        public decimal SellingPrice { get; set; }

        public DateTime SoldDate { get; set; }
    }
}