using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.Abstract;
using ZG.Common.Concrete;
using ZG.Domain.Abstract;
using ZG.Domain.DTO;

namespace ZG.Domain.Concrete
{
    public class OrderProcessor : IOrderProcessor
    {
        private IEmailProcessor _emailProcessor;

        public OrderProcessor(IEmailProcessor emailProcessor)
        {
            _emailProcessor = emailProcessor;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            _emailProcessor.ProcessEmail(EmailType.NewOrderNotificationToAdmin, null, "New Order", "Body", true);
        }
    }
}
