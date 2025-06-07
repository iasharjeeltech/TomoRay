using TomoRay.Domain.Static;

namespace TomoRay.Domain.Entities
{

    public class User : BaseEntity
    {
        public string FullName { get; set; }    // Full name
        public string Email { get; set; }       // Login Email
        public string PhoneNumber { get; set; } // Optional: Contact
        public string PasswordHash { get; set; } // For login
        public UserRole Role { get; set; }      // Admin / Supervisor / Staff
        public bool IsApproved { get; set; }    // Approved by admin
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
    }

}
