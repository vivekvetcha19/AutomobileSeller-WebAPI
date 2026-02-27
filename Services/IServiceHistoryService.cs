using AutomobileSeller.Models;

namespace AutomobileSeller.Services
{
    public interface IServiceHistoryService
    {
        Task<IEnumerable<ServiceHistory>> GetAllAsync();

        Task<ServiceHistory?> GetByIdAsync(int id);

        Task<ServiceHistory?> CreateAsync(ServiceHistory serviceHistory);
    }
}