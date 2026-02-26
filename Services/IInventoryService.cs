using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync();

        Task<Inventory?> GetByIdAsync(int id);

        Task<Inventory?> CreateAsync(Inventory inventory);

        Task<Inventory?> UpdateAsync(int id, Inventory inventory);

        Task<bool> DeleteAsync(int id);
    }
}
