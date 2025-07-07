using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces.Services
{
    public interface IUserService : IRepository<User>
    {
        Task UpdateUserAsync(User user);
        Task SaveAsync();
        Task RegisterAsync(User user, string password);
        Task<User?> LoginAsync(string email, string password);

    }
}
