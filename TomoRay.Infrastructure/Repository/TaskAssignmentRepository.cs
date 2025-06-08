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

    public class TaskAssignmentRepository : ITaskAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskAssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskAssignment>> GetAllAsync()
        {
            return await _context.TaskAssignments
                .Include(a => a.User)
                .Include(a => a.WorkTask)
                .ToListAsync();
        }

        public async Task<TaskAssignment?> GetByIdAsync(Guid id)
        {
            return await _context.TaskAssignments
                .Include(a => a.User)
                .Include(a => a.WorkTask)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(TaskAssignment assignment)
        {
            await _context.TaskAssignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskAssignment assignment)
        {
            _context.TaskAssignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.TaskAssignments.FindAsync(id);
            if (item != null)
            {
                _context.TaskAssignments.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
