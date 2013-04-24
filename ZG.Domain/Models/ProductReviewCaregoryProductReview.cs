

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductReviewCaregoryProductReview : IEntity  
    {
        public int Id { get; set; }
        public int ProductReviewCategoryID { get; set; }
        public int ProductReviewID { get; set; }
        public int Rating { get; set; }
        public bool Active { get; set; }
        public virtual ProductReview ProductReview { get; set; }
        public virtual ProductReviewCategory ProductReviewCategory { get; set; }
    }
}
