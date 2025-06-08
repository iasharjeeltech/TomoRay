using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task MarkAttendanceAsync(Attendance attendance);
        Task<IEnumerable<Attendance>> GetAllAsync();
    }
}
