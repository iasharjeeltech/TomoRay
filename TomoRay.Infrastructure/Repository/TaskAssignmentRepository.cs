using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;
using TomoRay.Infrastructure.Data;

namespace TomoRay.Infrastructure.Repository
{

    public class TaskAssignmentRepository : Repository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskAssignmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskAssignment assignment)
        {
            _context.TaskAssignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

    }
}
