

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class ProductOption : IEntity  
    {
        public ProductOption()
        {
            this.InventoryProductOptions = new List<InventoryProductOption>();
            this.OrderProductOptions = new List<OrderProductOption>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductOptionName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductOptionGroup { get; set; }
        public int ProductID { get; set; }
        public decimal PriceChange { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<InventoryProductOption> InventoryProductOptions { get; set; }
        public virtual ICollection<OrderProductOption> OrderProductOptions { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
