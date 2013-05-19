

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class ShippingProvider : IEntity  
    {
        public ShippingProvider()
        {
            this.Orders = new List<Order>();
            this.Shippings = new List<Shipping>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingProviderName { get; set; }
        public decimal ShippingCost { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
