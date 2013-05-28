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
        private IEmailService _emailService;

        public OrderService(IUnitOfWork uow, IEmailService emailService)
            : base(uow)
        {
            _emailService = emailService;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            //TODO: more order process steps


            _emailService.ProcessEmail(EmailType.NewOrderNotificationToAdmin, null, "New Order", "Body", true, null);
        }
    }
}
