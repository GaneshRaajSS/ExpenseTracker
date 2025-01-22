using Microsoft.SqlServer.Server;
using WebApplication1.DTO;
using WebApplication1.Models;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Interface
{
    public interface IUser
    {
        Task<User> RegisterUser(UserRegisterDTO userDto);
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int userId);
        Task<User?> validateUser(string email, string password);
        Task<IEnumerable<User>> GetUsersByRole(UserRole role);
        Task Save();
    }
}
