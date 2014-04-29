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
        List<ProvinceEditViewModel> GetProvinces(bool? active);
        Province GetProvinceById(int id);
        void Upsert(List<ProvinceEditViewModel> provinces);
    }

    public class ProvinceService : BaseService, IProvinceService
    {
        public ProvinceService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<ProvinceEditViewModel> GetProvinces(bool? active)
        {
            var provinceByActive = new ProvinceByActive(active);
            return UnitOfWork.Provinces.Matches(provinceByActive).Select(p => new ProvinceEditViewModel { Id = p.Id, CountryId = p.CountryId, ProvinceName = p.ProvinceName, ProvinceCode = p.ProvinceCode, Active = p.Active }).ToList();
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
                p.CountryId = province.CountryId;
                p.ProvinceName = province.ProvinceName;
                p.ProvinceCode = province.ProvinceCode;
                p.Active = province.Active;
            }
        }

        private void Create(ProvinceEditViewModel province)
        {
            var p = new Province()
            {
                CountryId = province.CountryId,
                ProvinceName = province.ProvinceName,
                ProvinceCode = province.ProvinceCode,
                Active = province.Active
            };

            UnitOfWork.Provinces.Add(p);
        }
    }
}
