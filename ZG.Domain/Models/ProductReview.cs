

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class ProductReview : IEntity  
    {
        public ProductReview()
        {
            this.ProductReviewCaregoryProductReviews = new List<ProductReviewCaregoryProductReview>();
        }

        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        [Required]
        [MaxLength(500)]
        public string ReviewText { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<ProductReviewCaregoryProductReview> ProductReviewCaregoryProductReviews { get; set; }
    }
}
