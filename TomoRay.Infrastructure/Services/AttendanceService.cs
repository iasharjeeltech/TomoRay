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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task MarkAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAsync(attendance);
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }
    }
}
