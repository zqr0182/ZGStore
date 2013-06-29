

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class ProductReviewCaregoryProductReview : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductReviewCategoryID { get; set; }
        public int ProductReviewID { get; set; }
        public int Rating { get; set; }
        public bool Active { get; set; }

        [ForeignKey("ProductReviewID")]
        public virtual ProductReview ProductReview { get; set; }

        [ForeignKey("ProductReviewCategoryID")]
        public virtual ProductReviewCategory ProductReviewCategory { get; set; }
    }
}
