using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.Abstract;
using ZG.Common.Concrete;
using ZG.Common.DTO;
using ZG.Domain.Concrete;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IOrderService
    {
        void ProcessOrder(Cart cart, CheckoutDetails checkoutDetails);
        IEnumerable<OrderStatus> GetOrderStatuses(bool isActive);
        IEnumerable<ShippingProvider> GetShippingProviders(bool isActive);
    }

    public class OrderService : BaseService, IOrderService
    {
        private IEmailService _emailService;

        public OrderService(IUnitOfWork uow, IEmailService emailService)
            : base(uow)
        {
            _emailService = emailService;
        }

        public void ProcessOrder(Cart cart, CheckoutDetails checkoutDetails)
        {
            AddOrder(cart, checkoutDetails);

            //TODO: payment processing

            _emailService.ProcessEmail(EmailType.NewOrderNotificationToAdmin, null, "Your Order", "Message Body", true, null);
        }

        private void AddOrder(Cart cart, CheckoutDetails checkoutDetails)
        {
            var order = new Order
            {
                FullName = checkoutDetails.PaymentInformation.BillingAdress.FullName,
                OrderNumber = Guid.NewGuid().ToString(),
                OrderDate = DateTime.Now,
                OrderStatusID = GetOrderStatusId(OrderStatusEnum.Accepted),
                ShippingProviderID = GetShippingProviderId(ShippingProviderEnum.USPS_Ground), //TODO: can NOT hard code here
                ShippingNumber = "Fake Number", //TODO: fix this
                BillingAddress1 = checkoutDetails.PaymentInformation.BillingAdress.Address1,
                BillingAddress2 = checkoutDetails.PaymentInformation.BillingAdress.Address2,
                BillingCity = checkoutDetails.PaymentInformation.BillingAdress.City,
                BillingStateID = checkoutDetails.PaymentInformation.BillingAdress.StateId,
                //BillingProvinceID = 9, //TODO: fix this
                BillingCountryID = checkoutDetails.PaymentInformation.BillingAdress.CountryId,
                BillingZipcode = checkoutDetails.PaymentInformation.BillingAdress.Zip,
                ShippingAddress1 = checkoutDetails.ShippingDetails.ShippingAddress.Address1,
                ShippingAddress2 = checkoutDetails.ShippingDetails.ShippingAddress.Address2,
                ShippingCity = checkoutDetails.ShippingDetails.ShippingAddress.City,
                ShippingStateID = checkoutDetails.ShippingDetails.ShippingAddress.StateId,
                ShippingProvinceID = 13, //TODO: fix this
                ShippingCountryID = checkoutDetails.ShippingDetails.ShippingAddress.CountryId,
                ShippingZipcode = checkoutDetails.ShippingDetails.ShippingAddress.Zip,
                Comments = "",
                DatePlaced = DateTime.Now,
                Total = cart.ComputeOrderTotal(),
                Shipping = 2.5m, //TODO: fix this
                Tax = 3.0m,  //TODO: fix this
                Active = true
            };

            UnitOfWork.Orders.Add(order);

            UnitOfWork.Commit();
        }

        private int GetOrderStatusId(OrderStatusEnum status)
        {
            var orderStatuses = ZGCache.Cache("OrderStatuses", () => { return GetOrderStatuses(true); }, TimeSpan.FromMinutes(60));
            return orderStatuses.Where(s => s.OrderStatusName == status.ToString()).Select(s => s.Id).FirstOrDefault();
        }

        public IEnumerable<OrderStatus> GetOrderStatuses(bool isActive)
        {
            var status = new OrderStatusByActive(isActive);
            return UnitOfWork.OrderStatuses.Matches(status).ToList();
        }

        public IEnumerable<ShippingProvider> GetShippingProviders(bool isActive)
        {
            var status = new ShippingProvidersByActive(isActive);
            return UnitOfWork.ShippingProviders.Matches(status).ToList();
        }

        private int GetShippingProviderId(ShippingProviderEnum provider)
        {
            var shippingProviders = ZGCache.Cache("ShippingProviders", () => { return GetShippingProviders(true); }, TimeSpan.FromMinutes(60));
            return shippingProviders.Where(s => s.ShippingProviderName == Util.ReplaceUnderscoreWithSpace(provider)).Select(s => s.Id).FirstOrDefault();
        }

    }
}
