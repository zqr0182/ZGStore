using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.DTO
{
    public class Address
    {
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(100, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Address1 { get; set; }

        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public int CountryId { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public int StateId { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Province { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MaximumLength, MinimumLength = 2)]
        public string Zip { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.RequiredAddressPhone)]
        [RegularExpression(Constants.PhonePatternTenDigits, ErrorMessage = ValidationErrorMessage.Phone)]
        public string Phone { get; set; }
    }
}
