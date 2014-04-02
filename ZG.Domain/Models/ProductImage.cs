using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class ProductImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
