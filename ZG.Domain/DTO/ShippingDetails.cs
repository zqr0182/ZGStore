using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;

namespace ZG.Domain.DTO
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(100, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Zip { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Country { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.RequiredAddressPhone)]
        [RegularExpression(Constants.PhonePatternTenDigits, ErrorMessage = ValidationErrorMessage.Phone)]
        public string Phone { get; set; }

        public bool GiftWrap { get; set; }
    }
}
