

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Coupon : IEntity  
    {
        public int Id { get; set; }
        public int CouponTypeID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string CouponCode { get; set; }
        public string CouponDescription { get; set; }
        public decimal Amount { get; set; }
        public bool IsCouponUnique { get; set; }
        public bool IsCanBeCombined { get; set; }
        public System.DateTime IssuedDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public bool Active { get; set; }
        public virtual CouponType CouponType { get; set; }
        public virtual Product Product { get; set; }
    }
}
