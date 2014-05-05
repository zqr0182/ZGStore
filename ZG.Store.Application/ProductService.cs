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
    public interface IProductService
    {
        ProductListViewModel GetProducts(string category, bool active, int page, int pageSize);
        ProductListViewModel GetActiveProducts(string category, int page, int pageSize);
        Product GetProductById(int id); 
        Product GetProductById(int id, params string[] includePaths); 
        ProductEditViewModel GetProductEditViewModel(Product prod, string prodImageDirectory);
        Product Update(ProductEditViewModel prod);
        Product Create(ProductEditViewModel prod);
        void Activate(int id);
        void Deactivate(int id);
        List<IdName> GetProductIdNames(bool active);
    }

    public class ProductService : BaseService, IProductService
    {
        readonly IFileService _fileService;
        public ProductService(IUnitOfWork uow, IFileService fileService) : base(uow)
        {
            _fileService = fileService;
        }

        public ProductListViewModel GetProducts(string category, bool active, int page, int pageSize)
        {
            var productsByCategory = new ProductsByCategory(category, active);
            IQueryable<Product> products = UnitOfWork.Products.Matches(productsByCategory);

            int totalProducts = products.Count();

            //products = products.Matches(new ProductsByPage(page, pageSize)); //This also works
            products = UnitOfWork.Products.Matches(new ProductsByPage(page, pageSize, productsByCategory));

            var productsPerPage = new ProductListViewModel
            {
                Products = products.Select(p => new ProductBriefInfo{ Id = p.Id, Name = p.Name, Description = p.Description, SalePrice = p.SalePrice, Active = p.Active}).ToList(),
                TotalProducts = totalProducts
            };

            return productsPerPage;
        }

        public ProductListViewModel GetActiveProducts(string category, int page, int pageSize)
        {
            return GetProducts(category, true, page, pageSize);
        }

        public Product GetProductById(int id)
        {
            return UnitOfWork.Products.MatcheById(id);
        }

        public Product GetProductById(int id, params string[] includePaths)
        {
            return UnitOfWork.Products.MatcheById(id, includePaths);
        }

        public ProductEditViewModel GetProductEditViewModel(Product prod, string prodImageDirectory)
        {
            var viewModel = new ProductEditViewModel()
            {
                Id = prod.Id,
                Name = prod.Name,
                CatalogNumber = prod.CatalogNumber,
                Description = prod.Description,
                SalePrice = prod.SalePrice,
                Weight = prod.Weight,
                ShippingWeight = prod.ShippingWeight,
                Height = prod.Height,
                ShippingHeight = prod.ShippingHeight,
                Length = prod.Length,
                ShippingLength = prod.ShippingLength,
                Width = prod.Width,
                ShippingWidth = prod.ShippingWidth,
                ProductLink = prod.ProductLink,
                IsReviewEnabled = prod.IsReviewEnabled,
                TotalReviewCount = prod.TotalReviewCount,
                RatingScore = prod.RatingScore,
                Active = prod.Active,
                ProductImageNames = _fileService.GetFileNames(prodImageDirectory, ImageFileNamePatterns.Patterns),
                Inventories = prod.Inventories.Select(i => new InventoryViewModel { Id = i.Id, ProductID = i.ProductID, ProductAmountOrdered = i.ProductAmountOrdered, ProductAmountInStock = i.ProductAmountInStock, Price = i.Price, SupplierIdName = new SupplierIdName { Id = i.SupplierId, Name = i.Supplier.Name }, Active = i.Active }).ToList(),
                ProductCategories = prod.ProductCategories.Select(c => new IdName { Id = c.Category.Id, Name = c.Category.CategoryName }).ToList()
            };

            return viewModel;
        }

        public Product Update(ProductEditViewModel prod)
        {
            var product = GetProductById(prod.Id, "ProductCategories", "Inventories");
            product.Name = prod.Name;
            product.CatalogNumber = prod.CatalogNumber;
            product.Description = prod.Description;
            product.SalePrice = prod.SalePrice;
            product.Weight = prod.Weight;
            product.ShippingWeight = prod.ShippingWeight;
            product.Height = prod.Height;
            product.ShippingHeight = prod.ShippingHeight;
            product.Length = prod.Length;
            product.ShippingLength = prod.ShippingLength;
            product.Width = prod.Width;
            product.ShippingWidth = prod.ShippingWidth;
            product.ProductLink = prod.ProductLink;
            product.IsReviewEnabled = prod.IsReviewEnabled;
            product.Active = prod.Active;

            product.ProductCategories.ToList().ForEach(c => UnitOfWork.ProductCategories.Remove(c));
            product.ProductCategories.Clear();
            prod.ProductCategories.ForEach(c => product.ProductCategories.Add(new ProductCategory { CategoryID = c.Id, ProductID = prod.Id, Active = true }));

            prod.Inventories.ForEach(i => UpdateProductInventories(i, product));

            UnitOfWork.Commit();

            return product;
        }

        public Product Create(ProductEditViewModel prod)
        {
            var product = new Product()
            {
                Name = prod.Name,
                CatalogNumber = prod.CatalogNumber,
                Description = prod.Description,
                SalePrice = prod.SalePrice,
                Weight = prod.Weight,
                ShippingWeight = prod.ShippingWeight,
                Height = prod.Height,
                ShippingHeight = prod.ShippingHeight,
                Length = prod.Length,
                ShippingLength = prod.ShippingLength,
                Width = prod.Width,
                ShippingWidth = prod.ShippingWidth,
                ProductLink = prod.ProductLink,
                IsReviewEnabled = prod.IsReviewEnabled,
                Active = prod.Active,

                ProductCategories = prod.ProductCategories.Select(pc => new ProductCategory {  ProductID = prod.Id, CategoryID = pc.Id, Active = true}).ToList(),
                Inventories = (ICollection<Inventory>)prod.Inventories.Select(i => new Inventory{ ProductID = i.ProductID, ProductAmountOrdered = i.ProductAmountOrdered, ProductAmountInStock = i.ProductAmountInStock, Price = i.Price, SupplierId = i.SupplierIdName.Id, Active = i.Active})
            };

            UnitOfWork.Products.Add(product);
            UnitOfWork.Commit();

            return product;
        }

        public void Activate(int id)
        {
            ToggleActive(id, true);
        }

        public void Deactivate(int id)
        {
            ToggleActive(id, false);
        }

        public List<IdName> GetProductIdNames(bool active)
        {
            var productByActive = new ProductByActive(active);
            return UnitOfWork.Products.Matches(productByActive)
                                       .Select(p => new IdName { Id = p.Id, Name = p.Name }).ToList();
        }

        private void UpdateProductInventories(InventoryViewModel inventory, Product prod)
        {
            if (inventory.Id > 0)
            {
                var inventoryInDb = prod.Inventories.FirstOrDefault(i => i.Id == inventory.Id);

                if (inventoryInDb != null)
                {
                    inventoryInDb.ProductAmountOrdered = inventory.ProductAmountOrdered;
                    inventoryInDb.ProductAmountInStock = inventory.ProductAmountInStock;
                    inventoryInDb.Price = inventory.Price;
                    inventoryInDb.SupplierId = inventory.SupplierIdName.Id;
                    inventoryInDb.Active = inventory.Active;
                }
            }
            else
            {
                var newInventory = new Inventory { ProductID = prod.Id, ProductAmountOrdered = inventory.ProductAmountOrdered, ProductAmountInStock = inventory.ProductAmountInStock, Price = inventory.Price, SupplierId = inventory.SupplierIdName.Id, Active = inventory.Active };
                prod.Inventories.Add(newInventory);
            }
        }

        private void ToggleActive(int id, bool active)
        {
            var product = GetProductById(id);
            product.Active = active;

            UnitOfWork.Commit();
        }
    }
}
