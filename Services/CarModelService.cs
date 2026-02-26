using AutomobileSeller.Data;
using AutomobileSeller.Models;
using AutomobileSeller.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _repository;

        public CarModelService(ICarModelRepository repository)
        {
            _repository = repository;
        }

        //public async Task<IEnumerable<CarModel>> GetAllAsync()
        //{
        //    return await _context.CarModels
        //        .Include(cm => cm.Brand)
        //        .ToListAsync();
        //}
        public async Task<IEnumerable<CarModel>> GetAllAsync()
        {
            return await _repository.GetAllWithBrandAsync();
        }
        //public async Task<CarModel?> GetByIdAsync(int id)
        //{
        //    return await _context.CarModels
        //        .Include(cm => cm.Brand)
        //        .FirstOrDefaultAsync(cm => cm.Id == id);
        //}
        public async Task<CarModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdWithBrandAsync(id);
        }

        public async Task<IEnumerable<CarModel>> GetByBrandIdAsync(int brandId)
        {
            return await _repository.GetByBrandIdWithBrandAsync(brandId);
        }

        public async Task<CarModel> CreateAsync(CarModel model)
        {
            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();
            return model;
        }

        public async Task<CarModel?> UpdateAsync(int id, CarModel model)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.Name = model.Name;
            existing.Price = model.Price;

            _repository.Update(existing);
            await _repository.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);

            if (model == null)
                return false;

            _repository.Delete(model);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
