using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomoRay.Domain.Entities;

namespace TomoRay.Domain.Entities
{
    public class TaskAssignment : BaseEntity
    {
        public Guid WorkTaskId { get; set; }          // reference to Task entity
        public Guid UserId { get; set; }          // reference to User entity
        public DateTime AssignedDate { get; set; }

        // Navigation Properties
        public WorkTask WorkTask { get; set; }
        public User User { get; set; }
    }

}
