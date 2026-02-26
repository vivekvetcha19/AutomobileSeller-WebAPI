using AutomobileSeller.Models;

namespace AutomobileSeller.Repositories
{
    public interface ICarModelRepository : IGenericRepository<CarModel>
    {
        Task<IEnumerable<CarModel>> GetAllWithBrandAsync();
        Task<CarModel?> GetByIdWithBrandAsync(int id);
        Task<IEnumerable<CarModel>> GetByBrandIdWithBrandAsync(int brandId);
    }
}