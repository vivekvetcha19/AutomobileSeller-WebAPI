using System;

namespace AutomobileSeller.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

    }
}
