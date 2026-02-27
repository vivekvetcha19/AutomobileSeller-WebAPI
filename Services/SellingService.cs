using AutomobileSeller.Data;
using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class SellingService : ISellingService
    {
        private readonly ApplicationDbContext _context;

        public SellingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SellingHistory>> GetAllAsync()
        {
            return await _context.SellingHistories
                .Include(s => s.Customer)
                .Include(s => s.CarModel)
                .ToListAsync();
        }

        public async Task<SellingHistory?> GetByIdAsync(int id)
        {
            return await _context.SellingHistories
                .Include(s => s.Customer)
                .Include(s => s.CarModel)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SellingHistory?> CreateAsync(SellingHistory selling)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️ Validate Customer
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.Id == selling.CustomerId);

                if (customer == null)
                    return null;

                // 2️ Validate CarModel
                var carModel = await _context.CarModels
                    .FirstOrDefaultAsync(c => c.Id == selling.CarModelId);

                if (carModel == null)
                    return null;

                // 3️ Validate Inventory
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(i => i.CarModelId == selling.CarModelId);

                if (inventory == null)
                    return null;

                // 4️ Check stock
                if (inventory.QuantityInStock < selling.QuantitySold)
                    return null;

                // 5️ Deduct stock
                inventory.QuantityInStock -= selling.QuantitySold;

                // 6️ Set SoldDate
                selling.SoldDate = DateTime.UtcNow;

                // 7️ Save sale
                await _context.SellingHistories.AddAsync(selling);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return await GetByIdAsync(selling.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}