using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface ICountryService
    {
        List<IdName> GetCountyIdNames(bool active, List<string> countryNames);
    }

    public class CountryService : BaseService, ICountryService
    {
        public CountryService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<IdName> GetCountyIdNames(bool active, List<string> countryNames)
        {
            var countryByActive = new CountriesByActive(active);
            bool ignoreCountryNames = (countryNames == null || !countryNames.Any());
            var query = UnitOfWork.Countries.Matches(countryByActive);

            if(!ignoreCountryNames)
            {
                query = query.Where(c => countryNames.Contains(c.Name));
            }

            var result = query.Select(p => new IdName { Id = p.Id, Name = p.Name }).OrderBy(c => c.Name).ToList();

            var us = result.FirstOrDefault(c => c.Name == Countries.UNITED_STATES);
            result.Remove(us);
            result.Insert(0, us);

            var cn = result.FirstOrDefault(c => c.Name == Countries.CHINA);
            result.Remove(cn);
            result.Insert(1, cn);

            return result;
        }
    }
}
