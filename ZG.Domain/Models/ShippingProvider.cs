

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ShippingProvider : IEntity  
    {
        public ShippingProvider()
        {
            this.Orders = new List<Order>();
            this.Shippings = new List<Shipping>();
        }

        public int Id { get; set; }
        public string ShippingProviderName { get; set; }
        public decimal ShippingCost { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
