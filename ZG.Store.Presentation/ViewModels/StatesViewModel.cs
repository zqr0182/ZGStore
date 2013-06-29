using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class StatesViewModel
    {
        public IEnumerable<State> States { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public int? StateId { get; set; }
    }
}