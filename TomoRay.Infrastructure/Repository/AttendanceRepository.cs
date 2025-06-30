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

    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

    }
}
