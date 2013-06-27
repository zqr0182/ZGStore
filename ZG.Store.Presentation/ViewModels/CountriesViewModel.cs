using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class CountriesViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public int SelectedCountryId { get; set; }
    }
}