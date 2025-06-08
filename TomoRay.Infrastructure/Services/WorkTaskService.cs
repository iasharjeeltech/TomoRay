using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;

namespace TomoRay.Infrastructure.Services
{
    public class WorkTaskService : IWorkTaskService
    {
        private readonly IWorkTaskRepository _repository;

        public WorkTaskService(IWorkTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WorkTask>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WorkTask?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(WorkTask task)
        {
            await _repository.AddAsync(task);
        }

        public async Task UpdateAsync(WorkTask task)
        {
            await _repository.UpdateAsync(task);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
