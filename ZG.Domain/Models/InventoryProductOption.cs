

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class InventoryProductOption : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int InventoryID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("InventoryID")]
        public virtual Inventory Inventory { get; set; }
        [Required]
        [ForeignKey("ProductOptionID")]
        public virtual ProductOption ProductOption { get; set; }
    }
}
