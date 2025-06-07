using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }

    }
}
