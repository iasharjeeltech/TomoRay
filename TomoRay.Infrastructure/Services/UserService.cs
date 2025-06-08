using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;
using TomoRay.Infrastructure.Repository;

namespace TomoRay.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUserByIdAsync(Guid id) =>
            await _userRepo.GetByIdAsync(id);

        public async Task<IEnumerable<User>> GetAllUsersAsync() =>
            await _userRepo.GetAllAsync();

        public async Task CreateUserAsync(User user) =>
            await _userRepo.AddAsync(user);

        public async Task UpdateUserAsync(User user) =>
            await _userRepo.UpdateAsync(user);

        public async Task DeleteUserAsync(Guid id) =>
            await _userRepo.DeleteAsync(id);

        public async Task RegisterAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine($"Password hashed: {user.PasswordHash}");
            await _userRepo.AddAsync(user);
        }


        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null) return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!verified || !user.IsApproved)
                return null;

            return user;
        }


    }


}
