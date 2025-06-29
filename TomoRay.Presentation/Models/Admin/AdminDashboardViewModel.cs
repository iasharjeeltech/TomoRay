using TomoRay.Domain.Entities;

namespace TomoRay.Presentation.Models.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalSupervisors { get; set; }
        public int TotalStaff { get; set; }
        public List<User> UnapprovedUsers { get; set; }
        public List<User> RecentUsers { get; set; }
    }
}
