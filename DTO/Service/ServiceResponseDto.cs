namespace AutomobileSeller.DTO.Service
{
    public class ServiceResponseDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CarModelName { get; set; } = string.Empty;

        public string ServiceDescription { get; set; } = string.Empty;

        public decimal ServiceCost { get; set; }

        public DateTime ServiceDate { get; set; }
    }
}