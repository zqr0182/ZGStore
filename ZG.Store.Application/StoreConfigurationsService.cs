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
            return UnitOfWork.StoreConfigurations.Matches(configsByActive)
                                        .Select(c => new StoreConfiguration
                                        {
                                            Id = c.Id,
                                            ConfigKey = c.ConfigKey,
                                            ConfigValue = c.ConfigValue,
                                            Active = c.Active
                                        }).ToList();
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
                Update(user);
            }
            else
            {
                Create(user);
            }
        }

        private void Update(StoreConfiguration config)
        {
            var c = GetStoreConfigurationById(config.Id);

            if (c != null)
            {
                UpdateConfig(u, user);
            }
        }

        private void Create(StoreConfiguration config)
        {
            var u = new User() { DateCreated = DateTime.Now};
            UpdateUser(u, user);

            UnitOfWork.Users.Add(u);
        }

        private void UpdateConfig(User userInDb, UserViewModel user)
        {
            userInDb.UserName = user.UserName;
            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Phone = user.Phone;
            userInDb.DateUpdated = DateTime.Now;
            userInDb.Active = user.Active;
        }
    }
}
