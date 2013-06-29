

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Order : IEntity
    {
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
        [Required]
        public int OrderStatusID { get; set; }
        [Required]
        public int ShippingProviderID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string BillingAddress1 { get; set; }
        [MaxLength(50)]
        public string BillingAddress2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string BillingCity { get; set; }
        [Required]
        public int BillingStateID { get; set; }
        public int? BillingProvinceID { get; set; }
        [Required]
        public int BillingCountryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string BillingZipcode { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingAddress1 { get; set; }
        [MaxLength(50)]
        public string ShippingAddress2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingCity { get; set; }
        [Required]
        public int ShippingStateID { get; set; }
        public int? ShippingProvinceID { get; set; }
        [Required]
        public int ShippingCountryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingZipcode { get; set; }
        [MaxLength(400)]
        public string Comments { get; set; }
        public System.DateTime DatePlaced { get; set; }
        public DateTime? DateShipped { get; set; }
        public decimal Total { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public bool Active { get; set; }

        [ForeignKey("BillingStateID")]        
        public virtual State BillingState { get; set; }
        [ForeignKey("BillingProvinceID")]
        public virtual Province BillingProvince { get; set; }
        [ForeignKey("BillingCountryID")]
        public virtual Country BillingCountry { get; set; }

        [ForeignKey("ShippingProviderID")]
        public virtual ShippingProvider ShippingProvider { get; set; }
        [ForeignKey("ShippingStateID")]
        public virtual State ShippingState { get; set; }
        [ForeignKey("ShippingProvinceID")]
        public virtual Province ShippingProvince { get; set; }
        [ForeignKey("ShippingCountryID")]
        public virtual Country ShippingCountry { get; set; }
        [ForeignKey("OrderStatusID")]
        public virtual OrderStatus OrderStatu { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
