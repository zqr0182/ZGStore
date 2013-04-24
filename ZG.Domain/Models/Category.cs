

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Category : IEntity  
    {
        public Category()
        {
            this.FeaturedProducts = new List<FeaturedProduct>();
            this.ProductCategories = new List<ProductCategory>();
        }

        public int Id { get; set; }
        public Nullable<int> ParentCategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<FeaturedProduct> FeaturedProducts { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
