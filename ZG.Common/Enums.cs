﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common
{
    public enum UpdateQuantityOption
    {
        Add,
        Update
    }

    public enum EmailType
    {
        General,
        NewOrderNotificationToAdmin
    }

    public enum EmailSendingStatus
    {
        Sending,
        Success,
        Failed
    }

    public enum CheckoutBreadCrumb
    {
        Billing,
        Shipping,
        ReviewOrder
    }

    public enum OrderStatusEnum
    {
        Accepted,
        Verifyed,
        Shipped,
        PaymentError
    }

    public enum ShippingProviderEnum
    {
        UPS,
        USPS_Ground
    }

    public enum SupplierStatus
    {
        Active,
        Inactive
    }
}
