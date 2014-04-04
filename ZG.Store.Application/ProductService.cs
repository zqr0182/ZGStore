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
        ProductsPerPage GetActiveProducts(string category, int page, int pageSize);
        Product GetProductById(int id);
        ProductEditViewModel GetProductEditViewModel(Product prod, string prodImageDirectory);
        void Update(Product prod);
    }

    public class ProductService : BaseService, IProductService
    {
        readonly IFileService _fileService;
        public ProductService(IUnitOfWork uow, IFileService fileService) : base(uow)
        {
            _fileService = fileService;
        }

        public ProductsPerPage GetActiveProducts(string category, int page, int pageSize)
        {
            var productsByCategory = new ProductsByCategory(category, true);
            IQueryable<Product> products = UnitOfWork.Products.Matches(productsByCategory);

            int totalProducts = products.Count();

            //products = products.Matches(new ProductsByPage(page, pageSize)); //This also works
            products = UnitOfWork.Products.Matches(new ProductsByPage(page, pageSize, productsByCategory));

            var productsPerPage = new ProductsPerPage
            {
                Products = products,
                TotalProducts = totalProducts
            };

            return productsPerPage;
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
                ProductName = prod.ProductName,
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

        public void Update(Product prod)
        {
            var product = GetProductById(prod.Id);
            product.ProductName = prod.ProductName;
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
        }
    }
}
