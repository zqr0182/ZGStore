using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZG.Common;

namespace ZG.Store.Presentation.ViewModels
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string LastName { get; set; }

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

        public bool GiftWrap { get; set; }
    }
}