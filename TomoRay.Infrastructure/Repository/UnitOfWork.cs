using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Application.Common.Interfaces;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Infrastructure.Data;
using TomoRay.Infrastructure.Services;

namespace TomoRay.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IAttendanceRepository AttendanceRepositoryUOW { get; private set; }

        public ITaskAssignmentRepository TaskAssignmentRepositoryUOW { get; private set; }

        public IUserRepository UserRepositoryUOW { get; private set; }

        public IWorkTaskRepository WorkTaskRepositoryUOW { get; private set; }

        public IWorkTaskService WorkTaskServiceUOW { get; private set; }

        public IUserService UserServiceUOW { get; private set; }

        public IAttendanceService AttendanceServiceUOW { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            AttendanceRepositoryUOW = new AttendanceRepository(_db);
            TaskAssignmentRepositoryUOW = new TaskAssignmentRepository(_db);
            UserRepositoryUOW = new UserRepository(_db);
            WorkTaskRepositoryUOW = new WorkTaskRepository(_db);

            WorkTaskServiceUOW = new WorkTaskService(WorkTaskRepositoryUOW, _db);
            UserServiceUOW = new UserService(UserRepositoryUOW, _db); // ✅ Yeh sahi hai
            AttendanceServiceUOW = new AttendanceService(AttendanceRepositoryUOW, _db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
