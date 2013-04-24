

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class OrderStatu : IEntity  
    {
        public OrderStatu()
        {
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string OrderStatusName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
