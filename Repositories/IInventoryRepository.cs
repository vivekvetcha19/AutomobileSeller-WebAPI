using AutomobileSeller.Models;

namespace AutomobileSeller.Repositories
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetAllWithModelAsync();
        Task<Inventory?> GetByIdWithModelAsync(int id);
        Task<Inventory?> GetByCarModelIdAsync(int carModelId);
    }
}