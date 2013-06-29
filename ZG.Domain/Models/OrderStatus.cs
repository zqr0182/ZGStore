

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class OrderStatus : IEntity  
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string OrderStatusName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
