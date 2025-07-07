using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces.Services;

namespace TomoRay.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IAttendanceRepository AttendanceRepositoryUOW { get; }
        public ITaskAssignmentRepository TaskAssignmentRepositoryUOW { get; }
        public IUserRepository UserRepositoryUOW { get; }
        public IWorkTaskRepository WorkTaskRepositoryUOW { get; }

        //service repo
        public IWorkTaskService WorkTaskServiceUOW { get; }    
        public IUserService UserServiceUOW { get; }
        public IAttendanceService AttendanceServiceUOW { get; }
    }
}
