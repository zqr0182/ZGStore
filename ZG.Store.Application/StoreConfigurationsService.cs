using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IStoreConfigurationsService
    {
        List<StoreConfiguration> GetStoreConfigurations(bool? active);
        StoreConfiguration GetStoreConfigurationById(int id);
        void Upsert(List<StoreConfiguration> configs);
    }

    public class StoreConfigurationsService : BaseService, IStoreConfigurationsService
    {
        public StoreConfigurationsService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public List<StoreConfiguration> GetStoreConfigurations(bool? active)
        {
            var configsByActive = new StoreConfigurationByActive(active);
            return UnitOfWork.StoreConfigurations.Matches(configsByActive).ToList();
        }

        public StoreConfiguration GetStoreConfigurationById(int id)
        {
            return UnitOfWork.StoreConfigurations.MatcheById(id);
        }

        public void Upsert(List<StoreConfiguration> configs)
        {
            configs.ForEach(c => Upsert(c));

            UnitOfWork.Commit();
        }

        private void Upsert(StoreConfiguration config)
        {
            if (config.Id > 0)
            {
                Update(config);
            }
            else
            {
                Create(config);
            }
        }

        private void Update(StoreConfiguration config)
        {
            var configInDb = GetStoreConfigurationById(config.Id);

            if (configInDb != null)
            {
                configInDb.ConfigKey = config.ConfigKey;
                configInDb.ConfigValue = config.ConfigValue;
                configInDb.Active = config.Active;
            }
        }

        private void Create(StoreConfiguration config)
        {
            UnitOfWork.StoreConfigurations.Add(config);
        }
    }
}
