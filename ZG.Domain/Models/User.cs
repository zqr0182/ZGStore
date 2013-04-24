

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class User : IEntity  
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Division { get; set; }
        public string Title { get; set; }
        public string BusinessType { get; set; }
        public string BusinessSize { get; set; }
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}
