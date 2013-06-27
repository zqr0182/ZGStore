using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class StatesViewModel
    {
        public IEnumerable<State> States { get; set; }
        public int SelectedStateId { get; set; }
    }
}