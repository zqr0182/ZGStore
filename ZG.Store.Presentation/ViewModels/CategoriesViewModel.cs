using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZG.Store.Presentation.ViewModels
{
    public class CategoriesViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}