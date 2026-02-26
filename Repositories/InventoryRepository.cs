using AutomobileSeller.Data;
using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Repositories
{
    public class InventoryRepository
        : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Inventory>> GetAllWithModelAsync()
        {
            return await _context.Inventories
                .Include(i => i.CarModel)
                .ToListAsync();
        }

        public async Task<Inventory?> GetByIdWithModelAsync(int id)
        {
            return await _context.Inventories
                .Include(i => i.CarModel)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> GetByCarModelIdAsync(int carModelId)
        {
            return await _context.Inventories
                .FirstOrDefaultAsync(i => i.CarModelId == carModelId);
        }
    }
}