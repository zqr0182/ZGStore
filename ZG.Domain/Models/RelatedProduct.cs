

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class RelatedProduct : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductOneID { get; set; }
        public int ProductTwoID { get; set; }
        public Nullable<bool> Active { get; set; }

        [ForeignKey("ProductOneID")]
        public virtual Product ProductOne { get; set; }

        [ForeignKey("ProductTwoID")]
        public virtual Product ProductTwo { get; set; }
    }
}
