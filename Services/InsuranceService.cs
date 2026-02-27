using AutomobileSeller.Data;
using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly ApplicationDbContext _context;

        public InsuranceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insurance>> GetAllAsync()
        {
            return await _context.Insurances
                .Include(i => i.Customer)
                .Include(i => i.CarModel)
                .ToListAsync();
        }

        public async Task<Insurance?> GetByIdAsync(int id)
        {
            return await _context.Insurances
                .Include(i => i.Customer)
                .Include(i => i.CarModel)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Insurance?> CreateAsync(Insurance insurance)
        {
            var customerExists = await _context.Customers
                .AnyAsync(c => c.Id == insurance.CustomerId);

            if (!customerExists)
                return null;

            var carModelExists = await _context.CarModels
                .AnyAsync(c => c.Id == insurance.CarModelId);

            if (!carModelExists)
                return null;

            // Validate dates
            if (insurance.ExpiryDate <= insurance.StartDate)
                return null;

            // Validate Selling record exists
            var selling = await _context.SellingHistories
                .FirstOrDefaultAsync(s =>
                    s.CustomerId == insurance.CustomerId &&
                    s.CarModelId == insurance.CarModelId);

            if (selling == null)
                return null;

            // Validate coverage amount
            if (insurance.CoverageAmount > selling.SellingPrice)
                return null;

            await _context.Insurances.AddAsync(insurance);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(insurance.Id);
        }
    }
}