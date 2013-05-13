using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ProductIdQuantity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CartTotalValue { get; set; }
    }
}
