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
    public interface IShippingProviderService
    {
        IQueryable<ShippingProvider> GetShippingProviders(bool active);
        ShippingProvider GetShippingProviderById(int id);
        void Activate(int id);
        void Deactivate(int id);
        void Update(ShippingProvider shippingProvider);
        void Create(ShippingProvider shippingProvider);
    }

    public class ShippingProviderService : BaseService, IShippingProviderService
    {
        public ShippingProviderService(IUnitOfWork uow)
            : base(uow)
        {}

        public IQueryable<ShippingProvider> GetShippingProviders(bool active)
        {
            var suppliersByActive = new ShippingProviderByActive(active);
            return UnitOfWork.ShippingProviders.Matches(suppliersByActive);
        }

        public ShippingProvider GetShippingProviderById(int id)
        {
            return UnitOfWork.ShippingProviders.MatcheById(id);
        }

        public void Activate(int id)
        {
            ToggleActive(id, true);
        }

        public void Deactivate(int id)
        {
            ToggleActive(id, false);
        }

        public void Update(ShippingProvider shippingProvider)
        {
            var sp = GetShippingProviderById(shippingProvider.Id);

            if (sp != null)
            {
                sp.Name = shippingProvider.Name;
                sp.ShippingCost = shippingProvider.ShippingCost;
                sp.Active = shippingProvider.Active;

                UnitOfWork.Commit();
            }
        }

        public void Create(ShippingProvider shippingProvider)
        {
            var sp = new ShippingProvider()
            {
                Name = shippingProvider.Name,
                ShippingCost = shippingProvider.ShippingCost,
                Active = shippingProvider.Active
            };

            UnitOfWork.ShippingProviders.Add(shippingProvider);
            UnitOfWork.Commit();
        }

        private void ToggleActive(int id, bool active)
        {
            var sp = GetShippingProviderById(id);
            sp.Active = active;

            UnitOfWork.Commit();
        }
    }
}
