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
        List<CountryIdName> GetCountries(bool? active);
    }

    public class CountryService : BaseService, ICountryService
    {
        public CountryService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<CountryIdName> GetCountries(bool? active)
        {
            var countryByActive = new CountryByActive(active);
            return UnitOfWork.Countries.Matches(countryByActive).Select(p => new CountryIdName { Id = p.Id, Name = p.Name}).ToList();
        }
    }
}
