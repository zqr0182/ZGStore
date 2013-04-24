

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductDownloadKey : IEntity  
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string DownloadKey { get; set; }
        public bool Active { get; set; }
        public virtual Product Product { get; set; }
    }
}
