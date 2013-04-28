

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Order : IEntity  
    {
        public Order()
        {
            this.OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> OrderStatusID { get; set; }
        public Nullable<int> ShippingProviderID { get; set; }
        public string ShippingNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Zipcode { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> DatePlaced { get; set; }
        public Nullable<System.DateTime> DateShipped { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public bool Active { get; set; }
        public virtual Country Country { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual Province Province { get; set; }
        public virtual ShippingProvider ShippingProvider { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
