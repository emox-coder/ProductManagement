using Microsoft.EntityFrameworkCore;
using ProductManagement.Features.Data;
using ProductManagement.Features.Data.Models;
using ProductManagement.Features.Repositories.Interfaces;

namespace ProductManagement.Features.Repositories.Implementations
{
    public class UserActivityLogRepository : IUserActivityLogRepository
    {
        private readonly AppDbContext _context;

        public UserActivityLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserActivityLog log)
        {
            _context.UserActivityLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserActivityLog>> GetAllAsync()
        {
            return await _context.UserActivityLogs
                .Include(l => l.User)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();
        }

        public async Task<UserActivityLog?> GetByIdAsync(int id)
        {
            return await _context.UserActivityLogs
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<UserActivityLog>> GetByUserIdAsync(int userId)
        {
            return await _context.UserActivityLogs
                .Include(l => l.User)
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();
        }
    }
}
