

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Inventory : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        [Required]
        public int ProductAmountInStock { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
