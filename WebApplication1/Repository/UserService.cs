using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplication1.Constants;
using WebApplication1.DTO;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    
    public class UserService : IUser
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserById(int userId)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.userId == userId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            { 
                throw (ex);
            }
        }

        public async Task<IEnumerable<User>> GetUsersByRole(MultiValues.UserRole role)
        {
            var adminUserType = MultiValues.UserRole.SuperAdmin;
            return await _context.Users
                .Where(u => u.Role == adminUserType)
                .ToListAsync();
        }

        public async Task<User> RegisterUser(UserRegisterDTO userDto)
        {

            var userRole = Regex.IsMatch(userDto.email, @"^admin_([a-zA-Z]+)_Tracker@gmail.com$", RegexOptions.IgnoreCase)
                ? MultiValues.UserRole.SuperAdmin : MultiValues.UserRole.User;

            var user = new User
            {
                userName = userDto.userName,
                email = userDto.email,
                password = userDto.password,
                phone = userDto.phone,
                Role = userRole
            };
            await _context.Users.AddAsync(user);
            try
            {
                
                await Save();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return user;
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<User?> validateUser(string email, string password)
        {
            try
            {
                var user = await _context.Users
                .FirstOrDefaultAsync(vu => EF.Functions.Collate(vu.email, "Latin1_General_BIN") == email &&
                         EF.Functions.Collate(vu.password, "Latin1_General_BIN") == password);

                return user;
            }
            catch (Exception ex)
            { 
                throw(ex);
            }
        }
    }
}
