using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Domain.Entities
{
    public class InventoryAssignment : BaseEntity
    {
        public Guid InventoryItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        public int QuantityAssigned { get; set; }

        // Navigation
        public InventoryItem InventoryItem { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
    }

}
