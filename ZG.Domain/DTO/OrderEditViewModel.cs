using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;

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
        public string BillingState { get; set; }
        public string BillingProvince { get; set; }
        [Required]
        public string BillingCountry { get; set; }
        [Required]
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        [Required]
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingProvince { get; set; }
        [Required]
        public string ShippingCountry { get; set; }
        [Required]
        public string ShippingZipcode { get; set; }
        public string Comments { get; set; }
        [Required]
        public DateTime DatePlaced { get; set; }
        public String DatePlacedString { get { return DatePlaced.ToString(Constants.MMMMddyyyyhhmmtt); } }
        public DateTime? DateShipped { get; set; }
        public String DateShippedString { get { return DateShipped.HasValue ? DateShipped.Value.ToString(Constants.MMMMddyyyyhhmmtt) : ""; } }
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
