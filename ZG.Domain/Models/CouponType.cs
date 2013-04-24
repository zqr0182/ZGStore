

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class CouponType : IEntity  
    {
        public CouponType()
        {
            this.Coupons = new List<Coupon>();
        }

        public int Id { get; set; }
        public string CouponTypeName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
