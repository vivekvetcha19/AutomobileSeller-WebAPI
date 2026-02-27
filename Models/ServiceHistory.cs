namespace AutomobileSeller.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = null!;

        public string ServiceDescription { get; set; } = string.Empty;

        public decimal ServiceCost { get; set; }

        public DateTime ServiceDate { get; set; }
    }
}