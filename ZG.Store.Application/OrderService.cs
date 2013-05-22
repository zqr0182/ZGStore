using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.Abstract;
using ZG.Common.DTO;
using ZG.Domain.Concrete;
using ZG.Repository;

namespace ZG.Application
{
    public interface IOrderService
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails); //TODO: add billing details
    }

    public class OrderService : BaseService, IOrderService
    {
        private IEmailSender _emailSender;

        public OrderService(IUnitOfWork uow, IEmailSender emailSender)
            : base(uow)
        {
            _emailSender = emailSender;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            _emailSender.Send(EmailType.NewOrderNotificationToAdmin, null, "New Order", "Body", true);
        }
    }
}
