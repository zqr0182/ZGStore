

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZG.Domain.Models
{
    public partial class ProductReviewCategory : IEntity  
    {
        public ProductReviewCategory()
        {
            this.ProductReviewCaregoryProductReviews = new List<ProductReviewCaregoryProductReview>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductReviewCategoryName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ProductReviewCaregoryProductReview> ProductReviewCaregoryProductReviews { get; set; }
    }
}
