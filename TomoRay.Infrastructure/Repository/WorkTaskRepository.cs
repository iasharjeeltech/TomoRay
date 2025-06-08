using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;
using TomoRay.Infrastructure.Data;

namespace TomoRay.Infrastructure.Repository
{

    public class WorkTaskRepository : IWorkTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkTask>> GetAllAsync()
        {
            return await _context.WorkTasks.Include(t => t.TaskAssignments).ToListAsync();
        }

        public async Task<WorkTask?> GetByIdAsync(Guid id)
        {
            return await _context.WorkTasks
                .Include(t => t.TaskAssignments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(WorkTask task)
        {
            await _context.WorkTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkTask task)
        {
            _context.WorkTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.WorkTasks.FindAsync(id);
            if (task != null)
            {
                _context.WorkTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
