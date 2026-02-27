using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface ISellingService
    {
        Task<IEnumerable<SellingHistory>> GetAllAsync();
        Task<SellingHistory?> GetByIdAsync(int id);
        Task<SellingHistory?> CreateAsync(SellingHistory selling);
    }
}