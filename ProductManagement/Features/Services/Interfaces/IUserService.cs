using ProductManagement.Features.Data.Models;

namespace ProductManagement.Features.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(User user);
        Task<User?> Login(string username, string password);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task UpdateUser(User user);
        Task DeleteUser(int id);



    }
}
