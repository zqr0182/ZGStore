

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class InventoryAction : IEntity  
    {
        public InventoryAction()
        {
            this.Inventories = new List<Inventory>();
        }

        public int Id { get; set; }
        public string InventoryActionName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
