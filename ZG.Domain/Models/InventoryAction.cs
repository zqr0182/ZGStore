

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class InventoryAction : IEntity  
    {
        public InventoryAction()
        {
            this.Inventories = new List<Inventory>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string InventoryActionName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
