using AutomobileSeller.Models;
using AutomobileSeller.Repositories;

namespace AutomobileSeller.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IGenericRepository<CarModel> _carModelRepository;

        public InventoryService(
            IInventoryRepository inventoryRepository,
            IGenericRepository<CarModel> carModelRepository)
        {
            _inventoryRepository = inventoryRepository;
            _carModelRepository = carModelRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllWithModelAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdWithModelAsync(id);
        }

        public async Task<Inventory?> CreateAsync(Inventory inventory)
        {
            // Check if CarModel exists
            var carModel = await _carModelRepository
                .GetByIdAsync(inventory.CarModelId);

            if (carModel == null)
                return null;

            // Business Rule: Only one inventory per CarModel
            var existingInventory = await _inventoryRepository
                .GetByCarModelIdAsync(inventory.CarModelId);

            if (existingInventory != null)
                return null;

            inventory.LastUpdated = DateTime.UtcNow;

            await _inventoryRepository.AddAsync(inventory);
            await _inventoryRepository.SaveChangesAsync();

            return await _inventoryRepository
                .GetByIdWithModelAsync(inventory.Id);
        }

        public async Task<Inventory?> UpdateAsync(int id, Inventory inventory)
        {
            var existing = await _inventoryRepository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.QuantityInStock = inventory.QuantityInStock;
            existing.LastUpdated = DateTime.UtcNow;

            _inventoryRepository.Update(existing);
            await _inventoryRepository.SaveChangesAsync();

            return await _inventoryRepository
                .GetByIdWithModelAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);

            if (inventory == null)
                return false;

            _inventoryRepository.Delete(inventory);
            await _inventoryRepository.SaveChangesAsync();

            return true;
        }
    }
}