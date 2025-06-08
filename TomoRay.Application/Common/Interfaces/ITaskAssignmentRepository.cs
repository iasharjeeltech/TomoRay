using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces
{
    public interface ITaskAssignmentRepository
    {
        Task<IEnumerable<TaskAssignment>> GetAllAsync();
        Task<TaskAssignment?> GetByIdAsync(Guid id);
        Task AddAsync(TaskAssignment assignment);
        Task UpdateAsync(TaskAssignment assignment);
        Task DeleteAsync(Guid id);
    }
}
