using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common
{
    public struct ValidationErrorMessage
    {
        public const string MinimumLength = "The {0} must be at least {2} characters long.";
        public const string MaximumLength = "Maximum {0} characters exceeded";
        public const string ConfirmPassword = "Please enter the same password again.";
        public const string Email = "Please enter a valid email address.";
        public const string ConfirmEmail = "Please enter the same e-mail address again.";
        public const string Required = "This field is required.";
        public const string RequiredAddressPhone = "Please supply a phone number so we can call if there are any problems using this address.";
        public const string Phone = "Please enter a valid phone number.";
    }

    public struct RoleName
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }

    public struct EmailSettingKey
    {
        public const string SmtpUserName = "SmtpUserName";
        public const string SmtpPassword = "SmtpPassword";
        public const string SmtpServerName = "SmtpServerName";
        public const string SmtpServerPort = "SmtpServerPort";
        public const string WriteAsFile = "WriteAsFile";
        public const string FileLocation = "FileLocation";
        public const string OrderNotificationToAddress = "OrderNotificationToAddress";
        public const string OrderNotificationToName = "OrderNotificationToName";
        public const string OrderNotificationCcAddress = "OrderNotificationCcAddress";
        public const string OrderNotificationFromAddress = "OrderNotificationFromAddress";
        public const string OrderNotificationFromName = "OrderNotificationFromName";
    }
}
