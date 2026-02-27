using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface IInsuranceService
    {
        Task<IEnumerable<Insurance>> GetAllAsync();
        Task<Insurance?> GetByIdAsync(int id);
        Task<Insurance?> CreateAsync(Insurance insurance);
    }
}