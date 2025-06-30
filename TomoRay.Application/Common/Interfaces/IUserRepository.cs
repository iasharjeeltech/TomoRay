using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task UpdateAsync(User user);
        Task<User?> GetByEmailAsync(string email); // extra method example
        Task SaveAsync(); 
    }
}
