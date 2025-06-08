using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces
{
    public interface IWorkTaskRepository
    {
        Task<IEnumerable<WorkTask>> GetAllAsync();
        Task<WorkTask?> GetByIdAsync(Guid id);
        Task AddAsync(WorkTask task);
        Task UpdateAsync(WorkTask task);
        Task DeleteAsync(Guid id);
    }
}
