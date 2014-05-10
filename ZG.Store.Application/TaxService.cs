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
    public interface ITaxService
    {
        List<TaxViewModel> GetTaxes(bool? active, int countryId);
        Tax GetTaxById(int id);
        void Upsert(List<TaxViewModel> taxes);
    }

    public class TaxService : BaseService, ITaxService
    {
        public TaxService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<TaxViewModel> GetTaxes(bool? active, int countryId)
        {
            var taxByCountry = new TaxByCountry(countryId, new TaxByActive(active));
            return UnitOfWork.Taxes.Matches(taxByCountry)
                                        .Select(s => new TaxViewModel
                                        {
                                            Id = s.Id,
                                            Name = s.Name,
                                            Fixed = s.Fixed,
                                            Amount = s.Amount,
                                            CountryId = s.CountryID,
                                            StateId = s.StateID,
                                            ProvinceId = s.ProvinceID,
                                            Active = s.Active
                                        }).ToList();
        }

        public Tax GetTaxById(int id)
        {
            return UnitOfWork.Taxes.MatcheById(id);
        }

        public void Upsert(List<TaxViewModel> taxes)
        {
            taxes.ForEach(s => Upsert(s));

            UnitOfWork.Commit();
        }

        private void Upsert(TaxViewModel tax)
        {
            if (tax.Id > 0)
            {
                Update(tax);
            }
            else
            {
                Create(tax);
            }
        }

        private void Update(TaxViewModel tax)
        {
            var t = GetTaxById(tax.Id);

            if (t != null)
            {
                UpdateTax(t, tax);
            }
        }

        private void Create(TaxViewModel tax)
        {
            var t = new Tax();
            UpdateTax(t, tax);

            UnitOfWork.Taxes.Add(t);
        }

        private void UpdateTax(Tax taxInDb, TaxViewModel tax)
        {
            taxInDb.Name = tax.Name;
            taxInDb.Fixed = tax.Fixed;
            taxInDb.Amount = tax.Amount;
            taxInDb.CountryID = tax.CountryId;
            taxInDb.StateID = tax.StateId;
            taxInDb.ProvinceID = tax.ProvinceId;
            taxInDb.Active = tax.Active;
        }
    }
}
