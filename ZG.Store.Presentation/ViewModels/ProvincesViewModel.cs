using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class ProvincesViewModel
    {
        public IEnumerable<Province> Provinces { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public int? ProvinceId { get; set; }
        public string Province { get; set; }
    }
}