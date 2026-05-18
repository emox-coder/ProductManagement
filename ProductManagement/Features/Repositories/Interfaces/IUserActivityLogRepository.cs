using ProductManagement.Features.Data.Models;

namespace ProductManagement.Features.Repositories.Interfaces
{
    public interface IUserActivityLogRepository
    {
        Task<List<UserActivityLog>> GetAllAsync();
        Task<List<UserActivityLog>> GetByUserIdAsync(int userId);
        Task<UserActivityLog?> GetByIdAsync(int id);
        Task AddAsync(UserActivityLog log);
    }
}
