using Microsoft.AspNetCore.Components.Forms;
using ProductManagement.Features.Data.Models;
using ProductManagement.Features.Repositories.Interfaces;
using ProductManagement.Features.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ProductManagement.Features.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IUserActivityLogService _activityLogService;

        public UserService(IUserRepository repo, IUserActivityLogService activityLogService)
        {
            _repo = repo;
            _activityLogService = activityLogService;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user != null)
            {
                // Log activity before deleting the user to avoid race conditions
                await _activityLogService.LogActivityAsync(user.Id, user.Username, "Delete", $"User account deleted by admin");
                await _repo.DeleteAsync(id);
            }
        }


        public Task<List<User>> GetAllUsers() => _repo.GetAllAsync();

        public Task<User?> GetUserById(int id) => _repo.GetByIdAsync(id) ?? throw new Exception("User not found");

        public async Task<User?> Login(string username, string password)
        {
            var user = await _repo.GetUserBynameAsync(username);
            if(user == null) return null;
            
            var inputHash = Hash(password);
            Console.WriteLine($"Login attempt for {username}:");
            Console.WriteLine($"Stored hash: {user.Password}");
            Console.WriteLine($"Input hash: {inputHash}");
            Console.WriteLine($"Hashes match: {user.Password == inputHash}");
            
            if(user.Password != inputHash)
                return null;
            
            await _activityLogService.LogActivityAsync(user.Id, user.Username, "Login", "User logged in successfully");
            return user;
        }

        public async Task Register(User user)
        {
            var existingUser = await _repo.GetUserBynameAsync(user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            user.Password = Hash(user.Password);

            await _repo.AddAsync(user);
            
            await _activityLogService.LogActivityAsync(user.Id, user.Username, "Register", "New user registered");
        }

        public async Task UpdateUser(User user)
        {
            await _repo.UpdateAsync(user);
            await _activityLogService.LogActivityAsync(user.Id, user.Username, "Update", "User profile updated");
        }

        private string Hash(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(password))).ToLowerInvariant();
        }

    }
}
