

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Province : IEntity  
    {
        public Province()
        {
            this.Addresses = new List<Address>();
            this.Orders = new List<Order>();
            this.Shippings = new List<Shipping>();
            this.Taxes = new List<Tax>();
        }

        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string Active { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
