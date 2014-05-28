using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderBriefInfo> Orders { get; set; }
        public int TotalOrders { get; set; }
    }
}
