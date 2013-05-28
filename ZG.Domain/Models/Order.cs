

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Order : IEntity
    {
        public Order()
        {
            this.OrderProducts = new List<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int OrderStatusID { get; set; }
        public int ShippingProviderID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        public int StateID { get; set; }
        public int? ProvinceID { get; set; }
        public int CountryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Zipcode { get; set; }
        [MaxLength(400)]
        public string Comments { get; set; }
        public System.DateTime DatePlaced { get; set; }
        public DateTime? DateShipped { get; set; }
        public decimal Total { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [Required]
        [ForeignKey("OrderStatusID")]
        public virtual OrderStatus OrderStatu { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }
        [Required]
        [ForeignKey("ShippingProviderID")]
        public virtual ShippingProvider ShippingProvider { get; set; }
        [Required]
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
