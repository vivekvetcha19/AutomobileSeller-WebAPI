using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface ICarModelService
    {
        Task<IEnumerable<CarModel>> GetAllAsync();

        Task<CarModel?> GetByIdAsync(int id);

        Task<IEnumerable<CarModel>> GetByBrandIdAsync(int brandId);

        Task<CarModel> CreateAsync(CarModel model);

        Task<CarModel?> UpdateAsync(int id, CarModel model);

        Task<bool> DeleteAsync(int id);
    }
}
