

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class OrderProductOption : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int OrderProductID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("OrderProductID")]
        public virtual OrderProduct OrderProduct { get; set; }
        [Required]
        [ForeignKey("ProductOptionID")]
        public virtual ProductOption ProductOption { get; set; }
    }
}
