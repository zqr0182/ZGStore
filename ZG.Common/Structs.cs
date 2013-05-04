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
        public const string ConfirmPassword = "Please enter the same password again.";
        public const string Email = "Please enter a valid email address.";
        public const string ConfirmEmail = "Please enter the same e-mail address again.";
        public const string Required = "This field is required.";
        public const string Phone = "Please enter a valid phone number.";
    }
}
