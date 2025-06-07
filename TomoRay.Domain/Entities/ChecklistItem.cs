using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Domain.Entities
{
    public class ChecklistItem : BaseEntity
    {
        public Guid WorkTaskId { get; set; }  // Change from TaskId
        public string Description { get; set; }
        public bool IsPhotoRequired { get; set; }

        // Navigation
        public WorkTask WorkTask { get; set; }  // ✅ Change from Task
    }
}
