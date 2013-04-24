

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class OrderProduct : IEntity  
    {
        public OrderProduct()
        {
            this.OrderProductCustomFields = new List<OrderProductCustomField>();
            this.OrderProductOptions = new List<OrderProductOption>();
        }

        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public string DownloadKey { get; set; }
        public string DownloadURL { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public bool Active { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProductCustomField> OrderProductCustomFields { get; set; }
        public virtual ICollection<OrderProductOption> OrderProductOptions { get; set; }
    }
}
