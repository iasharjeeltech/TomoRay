using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Presentation.Models
{
    public class MarkAttendanceViewModel
    {
        public Guid UserId { get; set; }

        public string? PhotoBase64 { get; set; } // Base64 from canvas (not IFormFile)
        public string LocationAddress { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }

}