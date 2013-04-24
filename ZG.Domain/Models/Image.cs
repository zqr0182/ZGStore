

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Image : IEntity  
    {
        public int Id { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public bool Active { get; set; }
        public virtual Product Product { get; set; }
    }
}
