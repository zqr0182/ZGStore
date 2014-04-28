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
        List<ShippingProviderEditViewModel> GetShippingProviders(bool? active);
        ShippingProvider GetShippingProviderById(int id);
        void Upsert(List<ShippingProviderEditViewModel> shippingProviders);
    }

    public class ShippingProviderService : BaseService, IShippingProviderService
    {
        public ShippingProviderService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<ShippingProviderEditViewModel> GetShippingProviders(bool? active)
        {
            var suppliersByActive = new ShippingProviderByActive(active);
            return UnitOfWork.ShippingProviders.Matches(suppliersByActive).Select(p => new ShippingProviderEditViewModel{ Id = p.Id, Name = p.Name, ShippingCost = p.ShippingCost, Active = p.Active}).ToList();
        }

        public ShippingProvider GetShippingProviderById(int id)
        {
            return UnitOfWork.ShippingProviders.MatcheById(id);
        }

        public void Upsert(List<ShippingProviderEditViewModel> shippingProviders)
        {
            shippingProviders.ForEach(p => Upsert(p));

            UnitOfWork.Commit();
        }

        private void Upsert(ShippingProviderEditViewModel shippingProvider)
        {
            if(shippingProvider.Id > 0)
            {
                Update(shippingProvider);
            }
            else
            {
                Create(shippingProvider);
            }
        }

        private void Update(ShippingProviderEditViewModel shippingProvider)
        {
            var sp = GetShippingProviderById(shippingProvider.Id);

            if (sp != null)
            {
                sp.Name = shippingProvider.Name;
                sp.ShippingCost = shippingProvider.ShippingCost;
                sp.Active = shippingProvider.Active;
            }
        }

        private void Create(ShippingProviderEditViewModel shippingProvider)
        {
            var sp = new ShippingProvider()
            {
                Name = shippingProvider.Name,
                ShippingCost = shippingProvider.ShippingCost,
                Active = shippingProvider.Active
            };

            UnitOfWork.ShippingProviders.Add(sp);
        }
    }
}
