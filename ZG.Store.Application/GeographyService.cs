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
        IEnumerable<State> GetStates(bool activeOnly = true);
        IEnumerable<Province> GetProvinces(bool activeOnly = true);
        IEnumerable<Country> GetUSAndCanada();
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

        public IEnumerable<Province> GetProvinces(bool activeOnly = true)
        {
            string key = activeOnly ? "ActiveProvinces" : "AllProvinces";
            return ZGCache.Cache(key, () =>
            {
                var provinces = UnitOfWork.Provinces.Matches(new ProvincesByActive(activeOnly)).ToList();
                return provinces;
            }, TimeSpan.FromMinutes(60));
        }

        public IEnumerable<Country> GetUSAndCanada()
        {
            return ZGCache.Cache("UsAndCanda", () =>
            {
                var usCanada = UnitOfWork.Countries.Matches(new USAndCanada()).ToList();
                return usCanada;
            }, TimeSpan.FromMinutes(60));
        }
    }
}
