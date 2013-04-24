

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class InventoryProductOption : IEntity  
    {
        public int Id { get; set; }
        public int InventoryID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ProductOption ProductOption { get; set; }
    }
}
