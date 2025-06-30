using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Application.Common.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task UpdateAsync(Attendance attendance);
        Task SaveAsync();
    }
}
