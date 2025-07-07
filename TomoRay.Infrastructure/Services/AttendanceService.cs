using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Domain.Entities;
using TomoRay.Infrastructure.Data;
using TomoRay.Infrastructure.Repository;

namespace TomoRay.Infrastructure.Services
{
    public class AttendanceService : Repository<Attendance> ,IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ApplicationDbContext _db;

        public AttendanceService(IAttendanceRepository attendanceRepository, ApplicationDbContext db) : base(db)
        {
            _attendanceRepository = attendanceRepository;
            _db = db;

        }


        public async Task MarkAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAsync(attendance);
        }
    }
}
