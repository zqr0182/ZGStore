

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class ProductOption : IEntity  
    {
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
 
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
