using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        [Required]
        public int ShippingProviderId { get; set; }
        [Required]
        public string ShippingNumber { get; set; }
        [Required]
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        [Required]
        public string BillingCity { get; set; }
        public int? BillingStateId { get; set; }
        public int? BillingProvinceId { get; set; }
        [Required]
        public int BillingCountryId { get; set; }
        [Required]
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        [Required]
        public string ShippingCity { get; set; }
        public int? ShippingStateId { get; set; }
        public int? ShippingProvinceId { get; set; }
        [Required]
        public int ShippingCountryId { get; set; }
        [Required]
        public string ShippingZipcode { get; set; }
        public string Comments { get; set; }
        [Required]
        public DateTime DatePlaced { get; set; }
        public DateTime? DateShipped { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal Shipping { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
