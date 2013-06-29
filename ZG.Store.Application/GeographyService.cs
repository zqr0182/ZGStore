using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Concrete;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IGeographyService
    {
        IEnumerable<State> GetStates(bool isActive = true);
        IEnumerable<Country> GetCountries(bool isActive = true);
    }

    public class GeographyService : BaseService, IGeographyService
    {
        public GeographyService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<State> GetStates(bool activeOnly = true)
        {
            string key = activeOnly ? "ActiveStates" : "AllStates";
            return ZGCache.Cache(key, () => 
            { 
                var states = UnitOfWork.States.Matches(new StatesByActive(activeOnly)).ToList();
                return states;
            }, TimeSpan.FromMinutes(60));
        }

        public IEnumerable<Country> GetCountries(bool activeOnly = true)
        {
            string key = activeOnly ? "ActiveCountries" : "AllCountries";
            return ZGCache.Cache(key, () => 
            {
                var countries = UnitOfWork.Countries.Matches(new CountriesByActive(activeOnly)).ToList(); 

                return countries;
            }, TimeSpan.FromMinutes(60));
        }
    }
}
