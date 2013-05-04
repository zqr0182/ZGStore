using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using ZG.Common;

namespace ZG.Store.Presentation.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("ZGStoreContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = ValidationErrorMessage.MinimumLength, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = ValidationErrorMessage.ConfirmPassword)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MinimumLength, MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "E-mail address:")]
        [EmailAddress(ErrorMessage = ValidationErrorMessage.Email)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [DataType(DataType.Text)]
        [Display(Name = "Confirm e-mail address:")]
        [StringLength(50, ErrorMessage = ValidationErrorMessage.MinimumLength, MinimumLength = 2)]
        [EmailAddress(ErrorMessage = ValidationErrorMessage.Email)]
        [Compare("UserName", ErrorMessage = ValidationErrorMessage.ConfirmEmail)]
        public string UserNameRetype { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [StringLength(100, ErrorMessage = ValidationErrorMessage.MinimumLength, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password:")]
        [Compare("Password", ErrorMessage = ValidationErrorMessage.ConfirmPassword)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [DataType(DataType.Text)]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [DataType(DataType.Text)]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [DataType(DataType.Text)]
        [Display(Name = "Phone: xxx-xxx-xxxx")]
        [RegularExpression(Constants.PhonePatternTenDigits, ErrorMessage = ValidationErrorMessage.Phone)]
        public string Phone { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
