using AutomobileSeller.Data;
using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Repositories
{
    public class CarModelRepository : GenericRepository<CarModel>, ICarModelRepository
    {
        public CarModelRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<CarModel>> GetAllWithBrandAsync()
        {
            return await _context.CarModels
                .Include(cm => cm.Brand)
                .ToListAsync();
        }

        public async Task<CarModel?> GetByIdWithBrandAsync(int id)
        {
            return await _context.CarModels
                .Include(cm => cm.Brand)
                .FirstOrDefaultAsync(cm => cm.Id == id);
        }

        public async Task<IEnumerable<CarModel>> GetByBrandIdWithBrandAsync(int brandId)
        {
            return await _context.CarModels
                .Include(cm => cm.Brand)
                .Where(cm => cm.BrandId == brandId)
                .ToListAsync();
        }
    }
}