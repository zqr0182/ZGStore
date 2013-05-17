

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class OrderProduct : IEntity
    {
        public OrderProduct()
        {
            this.OrderProductCustomFields = new List<OrderProductCustomField>();
            this.OrderProductOptions = new List<OrderProductOption>();
        }

        [Key]
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Shipping { get; set; }
        [MaxLength(50)]
        public string DownloadKey { get; set; }
        [MaxLength(400)]
        public string DownloadURL { get; set; }
        public System.DateTime OrderDate { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProductCustomField> OrderProductCustomFields { get; set; }
        public virtual ICollection<OrderProductOption> OrderProductOptions { get; set; }
    }
}
