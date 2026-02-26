using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(Brand brand);
        Task<Brand?> UpdateAsync(int id, Brand brand);
        Task<bool> DeleteAsync(int id);
    }
}