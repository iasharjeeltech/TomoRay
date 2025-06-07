using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime PunchInTime { get; set; }
        public string LocationCoordinates { get; set; }
        public string SelfieImageUrl { get; set; }

        // Navigation
        public User User { get; set; }
    }

}
