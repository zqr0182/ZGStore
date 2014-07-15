using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;

namespace ZG.Domain.DTO
{
    public class OrderSaveModel
    {
        public int Id { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        [Required]
        public int ShippingProviderId { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
