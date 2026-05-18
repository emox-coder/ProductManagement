using ProductManagement.Features.Data.Models;

namespace ProductManagement.Features.Services.Interfaces
{
    public interface IUserActivityLogService
    {
        Task<List<UserActivityLog>> GetAllLogsAsync();
        Task<List<UserActivityLog>> GetLogsByUserIdAsync(int userId);
        Task LogActivityAsync(int userId, string username, string action, string? description = null, string? ipAddress = null);
    }
}
