using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.DTO
{
    public class ProductIdQuantityAndCartSummary
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int NumberOfItems { get; set; }
        public string CartTotalValue { get; set; }
    }
}
