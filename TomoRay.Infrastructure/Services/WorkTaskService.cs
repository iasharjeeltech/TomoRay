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
using Microsoft.EntityFrameworkCore;

namespace TomoRay.Infrastructure.Services
{
    public class WorkTaskService : Repository<WorkTask>, IWorkTaskService
    {
        private readonly IWorkTaskRepository _repository;
        private readonly ApplicationDbContext _db;

        public WorkTaskService(IWorkTaskRepository repository, ApplicationDbContext db) : base(db)
        {
            _db = db;
            _repository = repository;
        }

        public async Task UpdateAsync(WorkTask task)
        {
            await _repository.UpdateAsync(task);
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
