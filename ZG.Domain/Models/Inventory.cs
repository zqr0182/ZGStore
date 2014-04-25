

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Inventory : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int ProductAmountInStock { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
