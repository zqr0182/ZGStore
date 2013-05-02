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
        public const string ConfirmPassword = "The password and confirmation password do not match.";
        //public const string Required = "This field is required.";
    }
}
