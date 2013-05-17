

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class Image : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> SortOrder { get; set; }
        [MaxLength(200)]
        public string ImageName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ImageURL { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
