

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class OrderProductOption : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int OrderProductID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }

        [ForeignKey("OrderProductID")]
        public virtual OrderProduct OrderProduct { get; set; }

        [ForeignKey("ProductOptionID")]
        public virtual ProductOption ProductOption { get; set; }
    }
}
