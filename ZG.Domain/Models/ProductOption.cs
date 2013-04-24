

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductOption : IEntity  
    {
        public ProductOption()
        {
            this.InventoryProductOptions = new List<InventoryProductOption>();
            this.OrderProductOptions = new List<OrderProductOption>();
        }

        public int Id { get; set; }
        public string ProductOptionName { get; set; }
        public string ProductOptionGroup { get; set; }
        public int ProductID { get; set; }
        public decimal PriceChange { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<InventoryProductOption> InventoryProductOptions { get; set; }
        public virtual ICollection<OrderProductOption> OrderProductOptions { get; set; }
        public virtual Product Product { get; set; }
    }
}
