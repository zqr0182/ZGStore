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
    public interface ISupplierService
    {
        IQueryable<Supplier> GetSuppliers(bool active);
        List<SupplierIdName> GetSupplierIdNames(bool active);
        Supplier GetSupplierById(int id);
        void Activate(int supplierId);
        void Deactivate(int supplierId);
        void Update(Supplier sup);
        void Create(Supplier sup);
    }

    public class SupplierService : BaseService, ISupplierService
    {
        public SupplierService(IUnitOfWork uow) :base(uow)
        {}

        public IQueryable<Supplier> GetSuppliers(bool active)
        {
            var suppliersByActive = new SupplierByActive(active);
            return UnitOfWork.Suppliers.Matches(suppliersByActive);
        }

        public List<SupplierIdName> GetSupplierIdNames(bool active)
        {
            var suppliers = GetSuppliers(active);
            return suppliers.Select(s => new SupplierIdName { Id = s.Id, Name = s.Name, Active = s.Active }).ToList();
        }

        public Supplier GetSupplierById(int id)
        {
            return UnitOfWork.Suppliers.MatcheById(id);
        }

        public void Activate(int supplierId)
        {
            ToggleActive(supplierId, true);
        }

        public void Deactivate(int supplierId)
        {
            ToggleActive(supplierId, false);
        }

        public void Update(Supplier sup)
        {
            var supplier = GetSupplierById(sup.Id);

            if(supplier != null)
            {
                supplier.Name = sup.Name;
                supplier.Address1 = sup.Address1;
                supplier.Address2 = sup.Address2;
                supplier.City = sup.City;
                supplier.State = sup.State;
                supplier.Zip = sup.Zip;
                supplier.Country = sup.Country;
                supplier.Phone = sup.Phone;
                supplier.Active = sup.Active;

                UnitOfWork.Commit();
            }
        }

        public void Create(Supplier sup)
        {
            var supplier = new Supplier()
            {
                Name = sup.Name,
                Address1 = sup.Address1,
                Address2 = sup.Address2,
                City = sup.City,
                State = sup.State,
                Zip = sup.Zip,
                Country = sup.Country,
                Phone = sup.Phone,
                Active = sup.Active
            };

            UnitOfWork.Suppliers.Add(supplier);
            UnitOfWork.Commit();
        }

        private void ToggleActive(int supplierId, bool active)
        {
            var sup = GetSupplierById(supplierId);
            sup.Active = active;

            UnitOfWork.Commit();
        }
    }
}
