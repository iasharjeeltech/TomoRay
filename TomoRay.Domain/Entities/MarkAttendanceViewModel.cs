using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Domain.Entities
{
    public class MarkAttendanceViewModel
    {
        public Guid UserId { get; set; }

        public IFormFile Photo { get; set; }            // For photo upload
        public string LocationAddress { get; set; }     // Address from browser
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string? Remarks { get; set; }
    }

