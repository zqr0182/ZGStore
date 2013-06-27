﻿using System;
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
        IList<State> GetStates(bool isActive = true);
        IList<Country> GetCountries(bool isActive = true);
    }

    public class GeographyService : BaseService, IGeographyService
    {
        public GeographyService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IList<State> GetStates(bool activeOnly = true)
        {
            string key = activeOnly ? "ActiveStates" : "AllStates";
            return ZGCache.Cache(key, () => { return UnitOfWork.States.Matches(new StatesByActive(activeOnly)).ToList(); }, TimeSpan.FromMinutes(60));
        }

        public IList<Country> GetCountries(bool activeOnly = true)
        {
            string key = activeOnly ? "ActiveCountries" : "AllCountries";
            return ZGCache.Cache(key, () => { return UnitOfWork.Countries.Matches(new CountriesByActive(activeOnly)).ToList(); }, TimeSpan.FromMinutes(60));
        }
    }
}
