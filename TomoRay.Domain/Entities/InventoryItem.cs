using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomoRay.Domain.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int QuantityAvailable { get; set; }

        public ICollection<InventoryAssignment> InventoryAssignments { get; set; }
    }

}
.
