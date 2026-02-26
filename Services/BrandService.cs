using AutomobileSeller.Data;
using AutomobileSeller.Models;
using AutomobileSeller.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            await _repository.AddAsync(brand);
            await _repository.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand?> UpdateAsync(int id, Brand brand)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.Name = brand.Name;
            existing.Country = brand.Country;

            _repository.Update(existing);
            await _repository.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _repository.GetByIdAsync(id);

            if (brand == null)
                return false;

            _repository.Delete(brand);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}