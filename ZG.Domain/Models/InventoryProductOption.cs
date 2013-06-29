

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class InventoryProductOption : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int InventoryID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }

        [ForeignKey("InventoryID")]
        public virtual Inventory Inventory { get; set; }

        [ForeignKey("ProductOptionID")]
        public virtual ProductOption ProductOption { get; set; }
    }
}
