

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductReviewCategory : IEntity  
    {
        public ProductReviewCategory()
        {
            this.ProductReviewCaregoryProductReviews = new List<ProductReviewCaregoryProductReview>();
        }

        public int Id { get; set; }
        public string ProductReviewCategoryName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ProductReviewCaregoryProductReview> ProductReviewCaregoryProductReviews { get; set; }
    }
}
