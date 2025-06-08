namespace TomoRay.Presentation.Models
{
    // Presentation > Models > MarkAttendanceViewModel.cs
    public class MarkAttendanceViewModel
    {
        public Guid UserId { get; set; }
        public string PhotoBase64 { get; set; }         // from canvas
        public string LocationAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string? Remarks { get; set; }
    }

}