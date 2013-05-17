

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class Inventory : IEntity  
    {
        public Inventory()
        {
            this.InventoryProductOptions = new List<InventoryProductOption>();
        }

        [Key]
        public int Id { get; set; }
        public int InventoryActionID { get; set; }
        public int ProductID { get; set; }
        public int ProductAmountInStock { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("InventoryActionID")]
        public virtual InventoryAction InventoryAction { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public virtual ICollection<InventoryProductOption> InventoryProductOptions { get; set; }
    }
}
