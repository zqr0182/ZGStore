

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Category : IEntity  
    {
        public Category()
        {
            this.FeaturedProducts = new List<FeaturedProduct>();
            this.ProductCategories = new List<ProductCategory>();
        }

        [Key]
        public int Id { get; set; }
        public int? ParentCategoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<FeaturedProduct> FeaturedProducts { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
