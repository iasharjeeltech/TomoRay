namespace TomoRay.Domain.Entities
{
    public class WorkTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime ScheduledDate { get; set; }

        public TaskStatus Status { get; set; }

        // Navigation
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<ChecklistItem> ChecklistItems { get; set; }
    }

}
