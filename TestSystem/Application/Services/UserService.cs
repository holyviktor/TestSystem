using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using TestSystem.Core.Entities;
using TestSystem.Core.Models;
using TestSystem.Infrastructure.Data;

namespace TestSystem.Application.Services
{
    public class UserService
    {
        private readonly TestSystemDbContext _dbContext;
        private readonly IdentityService _identityService;
        public UserService(TestSystemDbContext testSystemDbContext) {
            _dbContext = testSystemDbContext;
            _identityService = new IdentityService();
        }

        public async Task<string> SignInUser(string email, string password)
        {
            var user = await _dbContext.Users.Include(user => user.Role).SingleOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new Exception("UserNoFound");
            }

            if (user.Password != HashPassword(password))
            {
                throw new Exception("WrongPassword");
            }
            var data = new TokenGenerationRequest()
            {
                UserId = user.Id.ToString(),
                Email = user.Email,
                Role = user.Role.Name
            };
            return _identityService.GenerateToken(data);
        }

        public async Task<string> SignUpUser(string email, string password, string phoneNumber)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                throw new Exception("UserAlreadyExist");
            }

            user = new User
            {
                Email = email,
                Password = HashPassword(password),
                PhoneNumber = phoneNumber,
                RoleId = 1
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();


            return await SignInUser(email, password);

        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha256.ComputeHash(passwordBytes);

                // Перетворення хешу в рядок для збереження в базі даних
                var hashString = Convert.ToBase64String(hashBytes);
                return hashString;
            }
        }
    }
}
