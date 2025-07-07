using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;
using TomoRay.Infrastructure.Repository;
using TomoRay.Infrastructure.Data;
using System.Linq.Expressions;

namespace TomoRay.Infrastructure.Services
{
    public class UserService : Repository<User>, IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ApplicationDbContext _db;

        public UserService(IUserRepository userRepo, ApplicationDbContext db) : base(db)
        {
            _db = db;
            _userRepo = userRepo;
        }


        public async Task UpdateUserAsync(User user) =>
            await _userRepo.UpdateAsync(user);

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

        public  async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }


}
