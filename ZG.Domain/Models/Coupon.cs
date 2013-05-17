

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class Coupon : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int CouponTypeID { get; set; }
        public Nullable<int> ProductID { get; set; }
        [Required]
        [MaxLength(200)]
        public string CouponCode { get; set; }
        [MaxLength(50)]
        public string CouponDescription { get; set; }
        public decimal Amount { get; set; }
        public bool IsCouponUnique { get; set; }
        public bool IsCanBeCombined { get; set; }
        public System.DateTime IssuedDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CouponTypeID")]
        public virtual CouponType CouponType { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
