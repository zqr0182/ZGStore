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
            const string UnitedStates = "UNITED STATES";
            IQueryable<Country> allCountries = base.BuildQueryOver(queryBase);

            if (_activeOnly)
            {
                allCountries = allCountries.Where(s => s.Active);
            }

            var us = allCountries.Where(s => (s.Active) && s.CountryName == UnitedStates);
            var otherCountries = allCountries.Where(s => (s.Active) && s.CountryName != UnitedStates);

            return us.Union(otherCountries);
        }
    }
}