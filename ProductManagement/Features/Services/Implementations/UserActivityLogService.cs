using ProductManagement.Features.Data.Models;
using ProductManagement.Features.Repositories.Interfaces;
using ProductManagement.Features.Services.Interfaces;

namespace ProductManagement.Features.Services.Implementations
{
    public class UserActivityLogService : IUserActivityLogService
    {
        private readonly IUserActivityLogRepository _repo;

        public UserActivityLogService(IUserActivityLogRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserActivityLog>> GetAllLogsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<UserActivityLog>> GetLogsByUserIdAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task LogActivityAsync(int userId, string username, string action, string? description = null, string? ipAddress = null)
        {
            var log = new UserActivityLog
            {
                UserId = userId,
                Username = username,
                Action = action,
                Description = description,
                IpAddress = ipAddress,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(log);
        }
    }
}
