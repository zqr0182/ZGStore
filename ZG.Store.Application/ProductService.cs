using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        ProductEditViewModel GetProductEditViewModel(Product prod, string prodImageDirectory);
        Product Update(ProductEditViewModel prod);
        Product Create(ProductEditViewModel prod);
        void Activate(int prodId);
        void Deactivate(int prodId);
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
                Products = products.Select(p => new ProductBriefInfo{ Id = p.Id, Name = p.ProductName, Description = p.Description, Price = p.Price, SalePrice = p.SalePrice, Active = p.Active}),
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

        public ProductEditViewModel GetProductEditViewModel(Product prod, string prodImageDirectory)
        {
            var viewModel = new ProductEditViewModel()
            {
                Id = prod.Id,
                Name = prod.ProductName,
                CatalogNumber = prod.CatalogNumber,
                Description = prod.Description,
                Price = prod.Price,
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
                ProductImageNames = _fileService.GetFileNames(prodImageDirectory)
            };

            return viewModel;
        }

        public Product Update(ProductEditViewModel prod)
        {
            var product = GetProductById(prod.Id);
            product.ProductName = prod.Name;
            product.CatalogNumber = prod.CatalogNumber;
            product.Description = prod.Description;
            product.Price = prod.Price;
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

            UnitOfWork.Commit();

            return product;
        }

        public Product Create(ProductEditViewModel prod)
        {
            var product = new Product()
            {
                ProductName = prod.Name,
                CatalogNumber = prod.CatalogNumber,
                Description = prod.Description,
                Price = prod.Price,
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
                Active = prod.Active
            };

            UnitOfWork.Products.Add(product);
            UnitOfWork.Commit();

            return product;
        }

        public void Activate(int prodId)
        {
            ToggleActive(prodId, true);
        }

        public void Deactivate(int prodId)
        {
            ToggleActive(prodId, false);
        }

        private void ToggleActive(int prodId, bool active)
        {
            var product = GetProductById(prodId);
            product.Active = active;

            UnitOfWork.Commit();
        }
    }
}
