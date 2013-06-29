

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Tax : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public string TaxName { get; set; }
        public bool Fixed { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public bool IsAfterShipping { get; set; }
        public int CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public bool Active { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
    }
}
