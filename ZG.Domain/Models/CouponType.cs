

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class CouponType : IEntity  
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CouponTypeName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
