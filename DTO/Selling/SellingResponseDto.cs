namespace AutomobileSeller.DTO.Selling
{
    public class SellingResponseDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CarModelName { get; set; } = string.Empty;

        public int QuantitySold { get; set; }

        public decimal SellingPrice { get; set; }

        public DateTime SoldDate { get; set; }
    }
}