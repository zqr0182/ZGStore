using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<ProductCategory> ProductCategories { get; }
        IRepository<User> Users { get; }
        IRepository<Category> Categories { get; }
        IRepository<Email> Emails { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderStatus> OrderStatuses { get; }
        IRepository<ShippingProvider> ShippingProviders { get; }
        IRepository<Shipping> Shippings { get; }
        IRepository<State> States { get; }
        IRepository<Province> Provinces { get; }
        IRepository<Country> Countries { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Inventory> Inventories { get; }

        void Commit();
    }

    public class ZGStoreUnitOfWork : IUnitOfWork
    {
        private readonly ZGStoreContext _context;

        public IRepository<Product> Products { get; private set; }
        public IRepository<ProductCategory> ProductCategories { get; private set; }
        public IRepository<User> Users { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Email> Emails { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderStatus> OrderStatuses { get; private set; }
        public IRepository<ShippingProvider> ShippingProviders { get; private set; }
        public IRepository<Shipping> Shippings { get; private set; }
        public IRepository<State> States { get; private set; }
        public IRepository<Province> Provinces { get; private set; }
        public IRepository<Country> Countries { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
        public IRepository<Inventory> Inventories { get; private set; }

        public ZGStoreUnitOfWork(ZGStoreContext context, IRepository<Product> productRepo, IRepository<ProductCategory> productCategoriesRepo, IRepository<User> userRepo, IRepository<Category> categoryRepo, IRepository<Email> emailRepo,
                                 IRepository<Order> OrderRepo, IRepository<OrderStatus> orderStatusRepo, IRepository<ShippingProvider> shippingProvidersRepo, IRepository<Shipping> shippingsRepo, 
                                 IRepository<State> stateRepo, IRepository<Province> provinceRepo, IRepository<Country> countryRepo, IRepository<Supplier> supplierRepo, IRepository<Inventory> inventoryRepo)
        {
            _context = context;

            Products = productRepo;
            ProductCategories = productCategoriesRepo;
            Users = userRepo;
            Categories = categoryRepo;
            Emails = emailRepo;
            Orders = OrderRepo;
            OrderStatuses = orderStatusRepo;
            ShippingProviders = shippingProvidersRepo;
            Shippings = shippingsRepo;
            States = stateRepo;
            Provinces = provinceRepo;
            Countries = countryRepo;
            Suppliers = supplierRepo;
            Inventories = inventoryRepo;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
