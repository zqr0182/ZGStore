using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common
{
    public static class Constants
    {
        public static readonly DateTime DefaultDateTime = new DateTime(1900, 1, 1);
        public const string PhonePatternTenDigits = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        /// <summary>
        /// p
        /// </summary>
        public const string PageNumberQueryStringParam = "p";

        public const string ProductImageDirectory = "ProdImages";
    }

    public static class ImageFileNamePatterns
    {
        public static string[] Patterns 
        {
            get 
            {
                return new string[]{ "*.jpeg", "*.jpg", "*.bmp", "*.png" }; 
            }
        }
    }
}
