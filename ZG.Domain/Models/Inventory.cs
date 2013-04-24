

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Inventory : IEntity  
    {
        public Inventory()
        {
            this.InventoryProductOptions = new List<InventoryProductOption>();
        }

        public int Id { get; set; }
        public int InventoryActionID { get; set; }
        public int ProductID { get; set; }
        public int ProductAmountInStock { get; set; }
        public bool Active { get; set; }
        public virtual InventoryAction InventoryAction { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<InventoryProductOption> InventoryProductOptions { get; set; }
    }
}
