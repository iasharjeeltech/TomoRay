using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces.Services
{
    public interface IWorkTaskService : IRepository<WorkTask>
    {
        Task UpdateAsync(WorkTask task);
        Task SaveAsync();
    }
}
