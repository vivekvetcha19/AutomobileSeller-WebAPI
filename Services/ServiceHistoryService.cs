using AutomobileSeller.Data;
using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class ServiceHistoryService : IServiceHistoryService
    {
        private readonly ApplicationDbContext _context;

        public ServiceHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceHistory>> GetAllAsync()
        {
            return await _context.ServiceHistories
                .Include(s => s.Customer)
                .Include(s => s.CarModel)
                .ToListAsync();
        }

        public async Task<ServiceHistory?> GetByIdAsync(int id)
        {
            return await _context.ServiceHistories
                .Include(s => s.Customer)
                .Include(s => s.CarModel)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ServiceHistory?> CreateAsync(ServiceHistory serviceHistory)
        {
            // 1 Validate Customer
            var customerExists = await _context.Customers
                .AnyAsync(c => c.Id == serviceHistory.CustomerId);

            if (!customerExists)
                return null;

            // 2️ Validate CarModel
            var carModelExists = await _context.CarModels
                .AnyAsync(c => c.Id == serviceHistory.CarModelId);

            if (!carModelExists)
                return null;

            // 3️ Set ServiceDate
            serviceHistory.ServiceDate = DateTime.UtcNow;

            await _context.ServiceHistories.AddAsync(serviceHistory);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(serviceHistory.Id);
        }
    }
}