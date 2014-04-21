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
        IQueryable<Supplier> GetSuppliers(SupplierStatus status);
        List<SupplierIdName> GetSupplierIdNames(SupplierStatus status);
    }

    public class SupplierService : BaseService, ISupplierService
    {
        public SupplierService(IUnitOfWork uow) :base(uow)
        {}

        public IQueryable<Supplier> GetSuppliers(SupplierStatus status)
        {
            var suppliersByStatus = new SupplierByStatus(status);
            return UnitOfWork.Suppliers.Matches(suppliersByStatus);
        }

        public List<SupplierIdName> GetSupplierIdNames(SupplierStatus status)
        {
            var suppliers = GetSuppliers(status);
            return suppliers.Select(s => new SupplierIdName { Id = s.Id, Name = s.Name }).ToList();
        }
    }
}
