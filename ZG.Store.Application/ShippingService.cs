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
    public interface IShippingService
    {
        List<ShippingEditViewModel> GetShippings(bool? active, int countryId);
        Shipping GetShippingById(int id);
        void Upsert(List<ShippingEditViewModel> shippings);
    }

    public class ShippingService : BaseService, IShippingService
    {
        public ShippingService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<ShippingEditViewModel> GetShippings(bool? active, int countryId)
        {
            var shippingByCountry = new ShippingByCountry(countryId, new ShippingByActive(active));
            return UnitOfWork.Shippings.Matches(shippingByCountry)
                                       .Select(s => new ShippingEditViewModel
                                       {
                                           Id = s.Id,
                                           CountryID = s.CountryID,
                                           StateId = s.StateID,
                                           City = s.City,
                                           ProvinceId = s.ProvinceID,
                                           ProductId = s.ProductID,
                                           ShippingProviderId = s.ShippingProviderID,
                                           Rate = s.Rate,
                                           Active = s.Active
                                       }).ToList();
        }

        public Shipping GetShippingById(int id)
        {
            return UnitOfWork.Shippings.MatcheById(id);
        }

        public void Upsert(List<ShippingEditViewModel> shippings)
        {
            shippings.ForEach(s => Upsert(s));

            UnitOfWork.Commit();
        }

        private void Upsert(ShippingEditViewModel shipping)
        {
            if (shipping.Id > 0)
            {
                Update(shipping);
            }
            else
            {
                Create(shipping);
            }
        }

        private void Update(ShippingEditViewModel shipping)
        {
            var s = GetShippingById(shipping.Id);

            if (s != null)
            {
                UpdateShipping(s, shipping);
            }
        }

        private void Create(ShippingEditViewModel shipping)
        {
            var s = new Shipping();
            UpdateShipping(s, shipping);

            UnitOfWork.Shippings.Add(s);
        }

        private void UpdateShipping(Shipping shippingInDb, ShippingEditViewModel shipping)
        {
            shippingInDb.CountryID = shipping.CountryID;
            shippingInDb.StateID = shipping.StateId;
            shippingInDb.City = shipping.City;
            shippingInDb.ProvinceID = shipping.ProvinceId;
            shippingInDb.ProductID = shipping.ProductId;
            shippingInDb.ShippingProviderID = shipping.ShippingProviderId;
            shippingInDb.Rate = shipping.Rate;
            shippingInDb.Active = shipping.Active;
        }
    }
}
