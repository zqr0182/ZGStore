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
    public interface IProvinceService
    {
        List<ProvinceEditViewModel> GetProvinces(bool? active, int countryId);
        Province GetProvinceById(int id);
        void Upsert(List<ProvinceEditViewModel> provinces);
        List<IdName> GetProvinceIdNames(bool active, int countryId);
    }

    public class ProvinceService : BaseService, IProvinceService
    {
        public ProvinceService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<ProvinceEditViewModel> GetProvinces(bool? active, int countryId)
        {
            var provinceByCountry = new ProvinceByCountry(countryId, new ProvinceByActive(active));
            return UnitOfWork.Provinces.Matches(provinceByCountry).Select(p => new ProvinceEditViewModel { Id = p.Id, CountryId = p.CountryId, Name = p.Name, Code = p.Code, Active = p.Active }).ToList();
        }

        public Province GetProvinceById(int id)
        {
            return UnitOfWork.Provinces.MatcheById(id);
        }

        public void Upsert(List<ProvinceEditViewModel> provinces)
        {
            provinces.ForEach(p => Upsert(p));

            UnitOfWork.Commit();
        }

        public List<IdName> GetProvinceIdNames(bool active, int countryId)
        {
            var provinceByCountry = new ProvinceByCountry(countryId, new ProvinceByActive(active));
            return UnitOfWork.Provinces.Matches(provinceByCountry)
                                       .Select(p => new IdName { Id = p.Id, Name = p.Name }).ToList();
        }

        private void Upsert(ProvinceEditViewModel province)
        {
            if (province.Id > 0)
            {
                Update(province);
            }
            else
            {
                Create(province);
            }
        }

        private void Update(ProvinceEditViewModel province)
        {
            var p = GetProvinceById(province.Id);

            if (p != null)
            {
                UpdateProvince(p, province);
            }
        }

        private void Create(ProvinceEditViewModel province)
        {
            var p = new Province();
            UpdateProvince(p, province);

            UnitOfWork.Provinces.Add(p);
        }

        private void UpdateProvince(Province provinceInDb, ProvinceEditViewModel province)
        {
            provinceInDb.CountryId = province.CountryId;
            provinceInDb.Name = province.Name;
            provinceInDb.Code = province.Code;
            provinceInDb.Active = province.Active;
        }
    }
}
