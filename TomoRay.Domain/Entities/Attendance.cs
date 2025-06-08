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
        public DateTime MarkedAt { get; set; } = DateTime.Now;

        public string LocationAddress { get; set; } // like "Indore, MP"
        public string Latitude { get; set; }        // optional but helpful
        public string Longitude { get; set; }       // optional

        public string PhotoUrl { get; set; }        // saved image path or cloud URL
        public string? Remarks { get; set; }        // optional notes

        // Navigation
        public User User { get; set; }
    }


}
