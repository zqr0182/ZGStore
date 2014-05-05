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
            return UnitOfWork.Countries.Matches(countryByActive)
                                       .Where(c => ignoreCountryNames || countryNames.Contains(c.Name))
                                       .Select(p => new IdName { Id = p.Id, Name = p.Name }).ToList();
        }
    }
}
