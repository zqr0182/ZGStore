

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductReview : IEntity  
    {
        public ProductReview()
        {
            this.ProductReviewCaregoryProductReviews = new List<ProductReviewCaregoryProductReview>();
        }

        public int Id { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ReviewText { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public bool Active { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductReviewCaregoryProductReview> ProductReviewCaregoryProductReviews { get; set; }
    }
}
