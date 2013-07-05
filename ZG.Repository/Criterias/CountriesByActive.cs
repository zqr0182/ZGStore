using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class CountriesByActive : AbstractCriteria<Country>
    {
        private bool _activeOnly;

        public CountriesByActive(bool activeOnly)
        {
            _activeOnly = activeOnly;
        }

        public override IQueryable<Country> BuildQueryOver(IQueryable<Country> queryBase)
        {
            IQueryable<Country> allCountries = base.BuildQueryOver(queryBase);

            if (_activeOnly)
            {
                allCountries = allCountries.Where(s => s.Active);
            }

            return allCountries.OrderBy(c => c.CountryName);
        }
    }
}